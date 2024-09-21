using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.CompanyModel;
using Nop.Plugin.Widgets.Ecommerce.Domain;
using Nop.Plugin.Widgets.Ecommerce.Services.CompanyServices;
using Nop.Services;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.CompanyFactory;
public class CompanyModelFactory : ICompanyModelFactory
{

    #region Fields

    private readonly ICompanyService _companyService;
    private readonly IPictureService _pictureService;
    private readonly IWorkContext _workContext;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedModelFactory _localizedModelFactory;

    #endregion


    #region Ctor
    public CompanyModelFactory(ICompanyService companyService,
            IPictureService pictureService,
            IWorkContext workContext,
            ILocalizationService localizationService,
            ILocalizedModelFactory localizedModelFactory
        )
    {
        _companyService = companyService;
        _pictureService = pictureService;
        _workContext = workContext;
        _localizationService = localizationService;
        _localizedModelFactory = localizedModelFactory;
    }

    #endregion


    #region PrepareCompanyModelAsync
    public async Task<CompanyModel> PrepareCompanyModelAsync(CompanyModel model, Company company, bool excludeProperties = false)
    {

        Func<CompanyLocalizedModel, int, Task> localizedModelConfiguration = null;

        if (company != null)
        {
            if (model == null)
            {
                model = company.ToModel<CompanyModel>();
                model.CompanyTypeStr = Enum.GetName(typeof(CompanyTypes), company.CompanyType);
                var picture = await _pictureService.GetPictureByIdAsync(company.PictureId);
                (model.PictureThumbnailUrl, _) = await _pictureService.GetPictureUrlAsync(picture, 75);
            }

            localizedModelConfiguration = async (locale, languageId) =>
            {
                locale.Name = await _localizationService.GetLocalizedAsync(company, entity => entity.Name, languageId, false, false);
                locale.Description = await _localizationService.GetLocalizedAsync(company, entity => entity.Description, languageId, false, false);

            };


        }

        if (!excludeProperties)
        {
            model.AvailableCompanyOptions = ((CompanyTypes[])Enum.GetValues(typeof(CompanyTypes)))
                                                .Select(ct => new SelectListItem
                                                {
                                                    Value = ((int)ct).ToString(),
                                                    Text = ct.ToString()
                                                }).ToList();
            if (Enum.TryParse(typeof(CompanyTypes), model.CompanyTypeStr, out var companyTypeEnum))
                model.CompanyTypeStr = ((int)(CompanyTypes)companyTypeEnum).ToString();

            model.Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration);

        }


        return model;
    }

    #endregion


    #region PrepareCompanyListModelAsync
    public async Task<CompanyListModel> PrepareCompanyListModelAsync(CompanySearchModel searchModel)
    {
        if (searchModel == null)
            throw new ArgumentNullException(nameof(searchModel));


        var companys = await _companyService.SearchCompanysAsync(searchModel.SearchName, searchModel.SearchCompanyType, searchModel.SearchIsActive,
                                                    pageIndex: searchModel.Page - 1,
                                                    pageSize: searchModel.PageSize);

        var model = await new CompanyListModel().PrepareToGridAsync(searchModel, companys, () =>
        {
            return companys.SelectAwait(async company =>
            {
                return await PrepareCompanyModelAsync(null, company, true);
            });
        });

        return model;

    }

    #endregion


    #region PrepareCompanySearchModelAsync
    public async Task<CompanySearchModel> PrepareCompanySearchModelAsync(CompanySearchModel searchModel)
    {
        searchModel.AvailableCompanyOptions = (await CompanyTypes.Public.ToSelectListAsync()).ToList();
        searchModel.AvailableCompanyOptions.Insert(0,
            new SelectListItem
            {
                Text = "All",
                Value = "0"
            });

        searchModel.SetGridPageSize();

        return searchModel;
    }

    #endregion


}
