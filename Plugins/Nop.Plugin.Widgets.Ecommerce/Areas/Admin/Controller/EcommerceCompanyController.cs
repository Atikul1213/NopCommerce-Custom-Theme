using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model;
using Nop.Plugin.Widgets.Ecommerce.Domain;
using Nop.Plugin.Widgets.Ecommerce.Services;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Controller;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class EcommerceCompanyController : BasePluginController
{
    #region Fields

    private readonly ICompanyService _companyService;
    private readonly ICompanyModelFactory _companyModelFactory;
    private readonly IPictureService _pictureService;
    private readonly ILocalizedEntityService _localizedEntityService;

    #endregion

    #region Ctor
    public EcommerceCompanyController(
        ICompanyService companyService,
        ICompanyModelFactory companyModelFactory,
        IPictureService pictureService,
        ILocalizedEntityService localizedEntityService
        )
    {
        _companyService = companyService;
        _companyModelFactory = companyModelFactory;
        _pictureService = pictureService;
        _localizedEntityService = localizedEntityService;
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

    public async Task<IActionResult> List()
    {

        var searchModel = await _companyModelFactory.PrepareCompanySearchModelAsync(new Model.CompanySearchModel());

        return View("List", searchModel);
    }



    [HttpPost]
    public async Task<IActionResult> List(CompanySearchModel searchModel)
    {
        var model = await _companyModelFactory.PrepareCompanyListModelAsync(searchModel);

        return Json(model);
    }





    public async Task<IActionResult> Create()
    {
        var model = await _companyModelFactory.PrepareCompanyModelAsync(new CompanyModel(), null);

        return View("Create", model);
    }




    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Create(CompanyModel model, bool continueEditing)
    {
        if (ModelState.IsValid)
        {
            var company = model.ToEntity<Company>();
            company.CompanyType = Convert.ToInt32(model.CompanyTypeStr);
            await _companyService.InsertCompanyAsync(company);
            await UpdatePictureSeoNamesAsync(company);

            await UpdateLocalesAsync(company, model);

            return continueEditing ? RedirectToAction("Edit", new { id = company.Id }) : RedirectToAction("List");
        }

        model = await _companyModelFactory.PrepareCompanyModelAsync(model, null);

        return View("Create", model);
    }



    public async Task<IActionResult> Edit(int id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);

        if (company == null)
            return RedirectToAction("List");


        var model = await _companyModelFactory.PrepareCompanyModelAsync(null, company);

        return View("Edit", model);
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Edit(CompanyModel model, bool continueEditing)
    {
        var company = await _companyService.GetCompanyByIdAsync(model.Id);
        if (company == null)
            return RedirectToAction("List");


        if (ModelState.IsValid)
        {

            company = model.ToEntity<Company>();
            company.CompanyType = Convert.ToInt32(model.CompanyTypeStr);
            await _companyService.UpdateCompanyAsync(company);

            await UpdatePictureSeoNamesAsync(company);
            await UpdateLocalesAsync(company, model);

            return continueEditing ? RedirectToAction("Edit", new { id = company.Id }) : RedirectToAction("List");
        }

        model = await _companyModelFactory.PrepareCompanyModelAsync(model, company);
        return View("Edit", model);
    }




    [HttpPost]
    public async Task<IActionResult> Delete(CompanyModel model)
    {
        var company = await _companyService.GetCompanyByIdAsync(model.Id);
        if (company == null)
            return RedirectToAction("List");

        await _companyService.DeleteCompanyAsync(company);
        return RedirectToAction("List");
    }


    [HttpPost]

    public async Task<IActionResult> DeleteSelected(ICollection<int> selectedId)
    {


        if (selectedId == null || !selectedId.Any())
            return NoContent();
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
        }
        catch (Exception)
        {
            throw;
        }
        return Json(new { Result = true });
    }


    #endregion


}
