using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Plugin.Shipping.EuroQuip.Models;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Security;
using Nop.Services.Shipping;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Models.Extensions;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Shipping.EuroQuip.Controllers;

[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
[AutoValidateAntiforgeryToken]
public class ShippingEuroQuipController : BasePluginController
{
    #region Fields

    private readonly IPermissionService _permissionService;
    private readonly IShippingService _shippingService;
    private readonly ISettingService _settingService;
    private readonly IStoreService _storeService;
    private readonly ICountryService _countryService;

    #endregion


    #region Ctor
    public ShippingEuroQuipController(IPermissionService permissionService,
        IShippingService shippingService,
        ISettingService settingService,
        IStoreService storeService,
        ICountryService countryService)
    {
        _permissionService = permissionService;
        _shippingService = shippingService;
        _settingService = settingService;
        _storeService = storeService;
        _countryService = countryService;
    }

    #endregion



    #region Methods


    #region Configure

    public async Task<IActionResult> Configure(bool showtour = false)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageShippingSettings))
            return AccessDeniedView();

        var model = new ConfigurationModel();

        //stores
        model.AvailableStores.Add(new SelectListItem { Text = "*", Value = "0" });
        foreach (var store in await _storeService.GetAllStoresAsync())
            model.AvailableStores.Add(new SelectListItem { Text = store.Name, Value = store.Id.ToString() });
        //warehouses
        model.AvailableWarehouses.Add(new SelectListItem { Text = "*", Value = "0" });
        foreach (var warehouses in await _shippingService.GetAllWarehousesAsync())
            model.AvailableWarehouses.Add(new SelectListItem { Text = warehouses.Name, Value = warehouses.Id.ToString() });
        //shipping methods
        foreach (var sm in await _shippingService.GetAllShippingMethodsAsync())
            model.AvailableShippingMethods.Add(new SelectListItem { Text = sm.Name, Value = sm.Id.ToString() });
        //countries
        model.AvailableCountries.Add(new SelectListItem { Text = "*", Value = "0" });
        var countries = await _countryService.GetAllCountriesAsync();
        foreach (var c in countries)
            model.AvailableCountries.Add(new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        //states
        model.AvailableStates.Add(new SelectListItem { Text = "*", Value = "0" });


        model.SetGridPageSize();


        return View("~/Plugins/Shipping.EuroQuip/Views/Configure.cshtml", model);
    }




    [HttpPost]
    public async Task<IActionResult> Configure(ConfigurationModel model)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageShippingSettings))
            return Content("Access denied");



        return Json(new { Result = true });
    }


    #endregion



    #region FixedShippingRateList UpdateFixedShippingRate
    [HttpPost]
    public async Task<IActionResult> FixedShippingRateList(ConfigurationModel searchModel)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageShippingSettings))
            return await AccessDeniedDataTablesJson();

        var shippingMethods = (await _shippingService.GetAllShippingMethodsAsync()).ToPagedList(searchModel);

        var gridModel = await new FixedRateListModel().PrepareToGridAsync(searchModel, shippingMethods, () =>
        {
            return shippingMethods.SelectAwait(async shippingMethod => new FixedRateModel
            {
                ShippingMethodId = shippingMethod.Id,
                ShippingMethodName = shippingMethod.Name,

                Rate = await _settingService
                    .GetSettingByKeyAsync<decimal>(string.Format(EuroQuipDefaults.FIXED_RATE_SETTINGS_KEY, shippingMethod.Id)),
                IsPickUp = await _settingService
                    .GetSettingByKeyAsync<bool>(string.Format(EuroQuipDefaults.IS_PICKUP_SETTINGS_KEY, shippingMethod.Id))
            });
        });

        return Json(gridModel);
    }


    [HttpPost]
    public async Task<IActionResult> UpdateFixedShippingRate(FixedRateModel model)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageShippingSettings))
            return Content("Access denied");

        await _settingService.SetSettingAsync(string.Format(EuroQuipDefaults.FIXED_RATE_SETTINGS_KEY, model.ShippingMethodId), model.Rate, 0, false);
        await _settingService.SetSettingAsync(string.Format(EuroQuipDefaults.IS_PICKUP_SETTINGS_KEY, model.ShippingMethodId), model.IsPickUp, 0, false);

        await _settingService.ClearCacheAsync();

        return new NullJsonResult();
    }

    #endregion



    #endregion
}
