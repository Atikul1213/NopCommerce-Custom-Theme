using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;
using Nop.Plugin.Widgets.NopQuickTabs.Services;
using Nop.Services.Localization;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
public class TabFactories : ITabFactories
{
    private readonly ITabService _tabService;
    private readonly ILocalizationService _localizationService;
    public TabFactories(ITabService tabService, ILocalizationService localizationService)
    {
        _tabService = tabService;
        _localizationService = localizationService;
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

        return new TabModel()
        {
            Id = entity.Id,
            Title = entity.Title,
            ProductId = entity.ProductId,
            Description = entity.Description,
            DisplayOrder = entity.DisplayOrder,
            IsActive = entity.IsActive,
            ContentType = Enum.GetName(typeof(ContentTypes), entity.ContentType),
        };
    }

    public async Task<TabSearchModel> PrepareTabSearchModelAsync(TabSearchModel searchModel)
    {
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {

            ["Admin.Widget.NopQuickTab.Field.Title.Hint"] = "The title of the Tab",

            ["Admin.Widget.NopQuickTab.Field.Description.Hint"] = "The Description is the text that is show in the Product page",

            ["Admin.Widget.NopQuickTab.Field.DisplayOrder.Hint"] = "Display Order of the Tab",

            ["Admin.Widget.NopQuickTab.Field.IsActive.Hint"] = "Check to IsActive the Tab in the Product Page",

            ["Admin.Widget.NopQuickTab.Field.ContentType.Hint"] = "Choose a Content Type"

        });
        searchModel.SetGridPageSize();
        return searchModel;
    }
}
