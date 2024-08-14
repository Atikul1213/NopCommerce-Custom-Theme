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
            ContentType = model.ContentType
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

        var obj = new TabModel()
        {
            Id = entity.Id,
            Title = entity.Title,
            ProductId = entity.ProductId,
            Description = entity.Description,
            DisplayOrder = entity.DisplayOrder,
            IsActive = entity.IsActive,
            ContentType = entity.ContentType
        };
        return obj;
    }

    public async Task<TabSearchModel> PrepareTabSearchModelAsync(TabSearchModel searchModel)
    {
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            ["NopQuickTabs.Admin.NopProductsTabTitle"] = "Tabs",
            ["NopQuickTabs.Admin.NopProductsTabTitle.AddNewTab"] = "AddNewTab",
            ["NopQuickTabs.Admin.NopProductsTabTitle.ProductSpecificTabs"] = "Product specific tabs",

            ["Admin.Widget.NopQuickTab.Field.ProductId"] = "ProductId",
            ["Admin.Widget.NopQuickTab.Field.Title"] = "Title",
            ["Admin.Widget.NopQuickTab.Field.Description"] = "Description",
            ["Admin.Widget.NopQuickTab.Field.DisplayOrder"] = "Display Order",
            ["Admin.Widget.NopQuickTab.Field.IsActive"] = "IsActive",
            ["Admin.Widget.NopQuickTab.Field.ContentType"] = "Content Type"

        });
        searchModel.SetGridPageSize();
        return searchModel;
    }
}
