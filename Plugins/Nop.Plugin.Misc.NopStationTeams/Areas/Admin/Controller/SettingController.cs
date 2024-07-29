using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Caching;
using Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Factories;
using Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model.Settings;
using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Infrastructure;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;

namespace Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Controller;
public partial class SettingController : BaseAdminController
{   
    private readonly IPermissionService _permissionService;
    private readonly ISettingModelFactory _settingModelFactory;
    private readonly ISettingService _settingService;
    private readonly INotificationService _notificationService;
    private readonly ILocalizationService _localizationService;
    private readonly IStaticCacheManager _staticCacheManager;

    public SettingController
       
     (
        IPermissionService permissionService,
        ISettingModelFactory settingModelFactory,
        ISettingService settingService,
        INotificationService notificationService,
        ILocalizationService localizationService,
        IStaticCacheManager staticCacheManager
     )
    {
        _permissionService = permissionService;
        _settingModelFactory = settingModelFactory;
        _settingService = settingService;
        _notificationService = notificationService;
        _localizationService = localizationService;
        _staticCacheManager = staticCacheManager;
    }


    public virtual async Task<IActionResult> EmployeeOption()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageSettings))
            return AccessDeniedView();

        var model = await _settingModelFactory.PrepareEmployeeSettingModelAsync();


        return View("EmployeeOption", model);
    }


    [HttpPost]
    public virtual async Task<IActionResult> EmployeeOption(EmployeeSettingModel model)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageSettings))
            return AccessDeniedView();



        if(ModelState.IsValid)
        {
            var employeeSettings = await _settingService.LoadSettingAsync<EmployeeSettings>();

            employeeSettings = model.ToSettings(employeeSettings);

            await _settingService.SaveSettingOverridablePerStoreAsync(employeeSettings, x => x.IsMVP, model.IsMVP_OverrideForEmployee);
            await _settingService.SaveSettingOverridablePerStoreAsync(employeeSettings, x => x.IsCertified, model.IsCertified_OverrideForEmployee);
            await _settingService.SaveSettingOverridablePerStoreAsync(employeeSettings, x => x.IsDeleteAllow, model.IsDeleteAllow_OverrideForEmployee);
            await _settingService.SaveSettingOverridablePerStoreAsync(employeeSettings, x => x.AttachPdfInvoiceToAllEmployee, model.AttachPdfInvoiceToAllEmployee_OverrideForEmployee);
            await _settingService.SaveSettingOverridablePerStoreAsync(employeeSettings, x => x.AttachPdfInvoiceToIsMVPEmployee, model.AttachPdfInvoiceToIsMVPEmployee_OverrideForEmployee);
            await _settingService.SaveSettingOverridablePerStoreAsync(employeeSettings, x => x.AttachPdfInvoiceToCertifiedEmployee, model.AttachPdfInvoiceToCertifiedEmployee_OverrideForEmployee);




             await _staticCacheManager.RemoveAsync(NopModelCacheDefaults.PublicEmployeeAllModelKey);

            await _settingService.ClearCacheAsync();

            //if(model.OrderIdent.HasValue)
            //{
            //    try
            //    {

            //    }
            //    catch(Exception ex)
            //    {
            //        _notificationService.ErrorNotification(ex.Message);
            //    }
            //}

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Updated"));
            return RedirectToAction("EmployeeOption");
        }

        model = await _settingModelFactory.PrepareEmployeeSettingModelAsync(model);

        return View(model);
    }

    
}
