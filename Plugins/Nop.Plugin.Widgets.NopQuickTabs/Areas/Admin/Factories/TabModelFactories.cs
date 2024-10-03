using Nop.Core;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;
using Nop.Plugin.Widgets.NopQuickTabs.Services;
using Nop.Services.Localization;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
public class TabModelFactories : ITabModelFactorie
{
    private readonly ITabService _tabService;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedModelFactory _localizedModelFactory;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly IWorkContext _workContext;
    public TabModelFactories(ITabService tabService, ILocalizationService localizationService, ILocalizedModelFactory localizedModelFactory, ILocalizedEntityService localizedEntityService, IWorkContext workContext)
    {
        _tabService = tabService;
        _localizationService = localizationService;
        _localizedModelFactory = localizedModelFactory;
        _localizedEntityService = localizedEntityService;
        _workContext = workContext;
    }





    public async Task<Tab> PrepareTabAsync(TabModel model)
    {
        if (model == null)
            throw new NotImplementedException();

        var entity = new Tab()
        {

            Title = model.Title,
            ProductId = model.ProductId,
            Description = model.Description,
            DisplayOrder = model.DisplayOrder,
            IsActive = model.IsActive,
            ContentType = Convert.ToInt32(model.ContentType),
        };



        return entity;

    }

    public async Task<Tab> PrepareTabDataTableAsync(TabModel model)
    {
        if (model == null)
            throw new NotImplementedException();

        var tabModel = await _tabService.GetTabByIdAsync(model.Id);

        var entity = new Tab()
        {
            Title = model.Title,
            ProductId = model.ProductId,
            Description = model.Description,
            DisplayOrder = model.DisplayOrder,
            IsActive = model.IsActive,
            ContentType = tabModel.ContentType
        };



        return entity;
    }




    public async Task<TabListModel> PrepareTabListModelAsync(TabSearchModel searchModel, int productId)
    {
        ArgumentNullException.ThrowIfNull(searchModel);
        ArgumentNullException.ThrowIfNull(productId);


        searchModel.SetGridPageSize();
        var tabList = await _tabService.GetAllTabAsync(productId, pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);


        var tabModel = await new TabListModel().PrepareToGridAsync(searchModel, tabList, () =>
        {
            return tabList.SelectAwait(async obj =>
            {
                return await PrepareTabModelAsync(new TabModel(), obj);
            });
        });

        return tabModel;

    }





    public async Task<TabModel> PrepareTabModelAsync(TabModel model, Tab entity)
    {
        if (entity == null)
            throw new NotImplementedException();
        var lang = await _workContext.GetWorkingLanguageAsync();

        Func<TabLocalizedModel, int, Task> localizedModelConfiguration = async (locale, languageId) =>
        {
            locale.Title = await _localizationService.GetLocalizedAsync(entity, e => e.Title, languageId);
            locale.Description = await _localizationService.GetLocalizedAsync(entity, e => e.Description, languageId);
        };

        return new TabModel()
        {
            Id = entity.Id,
            //Title = entity.Title,
            Title = await _localizationService.GetLocalizedAsync(entity, x => x.Title, lang.Id),
            ProductId = entity.ProductId,
            //Description = entity.Description,
            Description = await _localizationService.GetLocalizedAsync(entity, x => x.Description, lang.Id),
            DisplayOrder = entity.DisplayOrder,
            IsActive = entity.IsActive,
            ContentType = Enum.GetName(typeof(ContentTypes), entity.ContentType),
            Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration)
        };





    }








    public async Task<TabSearchModel> PrepareTabSearchModelAsync(TabSearchModel searchModel)
    {

        searchModel.SetGridPageSize();
        return searchModel;
    }



    public virtual async Task UpdateLocalesAsync(Tab tab, TabModel tabModel)
    {
        foreach (var localized in tabModel.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(tab,
                x => x.Title,
                localized.Title,
                localized.LanguageId);

            await _localizedEntityService.SaveLocalizedValueAsync(tab,
                x => x.Description,
                localized.Description,
                localized.LanguageId);

        }
    }




}
