using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.CompanyFactory;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.CompanyModel;
using Nop.Plugin.Widgets.Ecommerce.Domain;
using Nop.Plugin.Widgets.Ecommerce.Services.CompanyServices;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Controller;

public class CompanyController : BaseAdminController
{
    #region Fields

    private readonly ICompanyService _companyService;
    private readonly ICompanyModelFactory _companyModelFactory;
    private readonly IPictureService _pictureService;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly ILocalizationService _localizationService;

    #endregion

    #region Ctor
    public CompanyController(
        ICompanyService companyService,
        ICompanyModelFactory companyModelFactory,
        IPictureService pictureService,
        ILocalizedEntityService localizedEntityService,
        INotificationService notificationService,
        IPermissionService permissionService,
        ILocalizationService localizationService
        )
    {
        _companyService = companyService;
        _companyModelFactory = companyModelFactory;
        _pictureService = pictureService;
        _localizedEntityService = localizedEntityService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _localizationService = localizationService;
    }

    #endregion

    #region Utilities

    protected virtual async Task UpdatePictureSeoNamesAsync(Company company)
    {
        var picture = await _pictureService.GetPictureByIdAsync(company.PictureId);
        if (picture != null)
            await _pictureService.SetSeoFilenameAsync(picture.Id, await _pictureService.GetPictureSeNameAsync(company.Name));
    }




    protected virtual async Task UpdateLocalesAsync(Company company, CompanyModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(company,
                x => x.Name,
                localized.Name,
                localized.LanguageId);

            await _localizedEntityService.SaveLocalizedValueAsync(company,
                x => x.Description,
                localized.Description,
                localized.LanguageId);

        }
    }

    #endregion

    #region Method List Create Edit Delete


    public async Task<IActionResult> Index()
    {
        return RedirectToAction("List");
    }


    public async Task<IActionResult> List()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
            return AccessDeniedView();

        var searchModel = await _companyModelFactory.PrepareCompanySearchModelAsync(new CompanySearchModel());

        return View(searchModel);
    }



    [HttpPost]
    public async Task<IActionResult> List(CompanySearchModel searchModel)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
            return AccessDeniedView();

        var model = await _companyModelFactory.PrepareCompanyListModelAsync(searchModel);

        return Json(model);
    }





    public async Task<IActionResult> Create()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
            return AccessDeniedView();

        var model = await _companyModelFactory.PrepareCompanyModelAsync(new CompanyModel(), null);

        return View(model);
    }




    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Create(CompanyModel model, bool continueEditing)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
            return AccessDeniedView();

        if (ModelState.IsValid)
        {
            var company = model.ToEntity<Company>();
            company.CompanyType = Convert.ToInt32(model.CompanyTypeStr);
            await _companyService.InsertCompanyAsync(company);
            await UpdatePictureSeoNamesAsync(company);

            await UpdateLocalesAsync(company, model);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Widget.Ecommerce.Company.Created"));

            return continueEditing ? RedirectToAction("Edit", new { id = company.Id }) : RedirectToAction("List");
        }

        model = await _companyModelFactory.PrepareCompanyModelAsync(model, null);

        return View(model);
    }



    public async Task<IActionResult> Edit(int id)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
            return AccessDeniedView();

        var company = await _companyService.GetCompanyByIdAsync(id);

        if (company == null)
        {
            var message = await _localizationService.GetResourceAsync("Nop.Plugin.Widget.Ecommerce.Company.NotFound");
            _notificationService.ErrorNotification(message);
            return RedirectToAction("List");
        }


        var model = await _companyModelFactory.PrepareCompanyModelAsync(null, company);

        return View(model);
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Edit(CompanyModel model, bool continueEditing)
    {

        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
            return AccessDeniedView();


        var company = await _companyService.GetCompanyByIdAsync(model.Id);
        if (company == null)
        {

            var message = await _localizationService.GetResourceAsync("Nop.Plugin.Widget.Ecommerce.Company.EditFailed");
            _notificationService.ErrorNotification(message);

            return RedirectToAction("List");
        }


        if (ModelState.IsValid)
        {

            company = model.ToEntity<Company>();
            company.CompanyType = Convert.ToInt32(model.CompanyTypeStr);
            await _companyService.UpdateCompanyAsync(company);

            await UpdatePictureSeoNamesAsync(company);
            await UpdateLocalesAsync(company, model);
            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Widget.Ecommerce.Company.UpdateSuccessfully"));
            return continueEditing ? RedirectToAction("Edit", new { id = company.Id }) : RedirectToAction("List");
        }

        model = await _companyModelFactory.PrepareCompanyModelAsync(model, company);

        return View(model);
    }




    [HttpPost]
    public async Task<IActionResult> Delete(CompanyModel model)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
            return AccessDeniedView();

        var company = await _companyService.GetCompanyByIdAsync(model.Id);
        if (company == null)
        {
            _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Widget.Ecommerce.Company.NotFound"));
            return RedirectToAction("List");
        }

        await _companyService.DeleteCompanyAsync(company);
        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Widget.Ecommerce.Company.Deleted"));

        return RedirectToAction("List");
    }


    [HttpPost]

    public async Task<IActionResult> DeleteSelected(ICollection<int> selectedId)
    {


        if (selectedId == null || !selectedId.Any())
        {
            _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Widget.Ecommerce.Company.NotFound"));
            return RedirectToAction("List");
        }
        try
        {
            foreach (var id in selectedId)
            {
                var company = await _companyService.GetCompanyByIdAsync(id);
                if (company != null)
                {
                    await _companyService.DeleteCompanyAsync(company);
                }
            }

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Widget.Ecommerce.Company.Deleted"));
        }
        catch (Exception)
        {
            throw;
        }

        return Json(new { Result = true });
    }


    #endregion


}
