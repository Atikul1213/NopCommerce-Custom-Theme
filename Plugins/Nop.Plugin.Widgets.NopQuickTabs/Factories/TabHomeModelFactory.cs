using Nop.Plugin.Widgets.NopQuickTabs.Domains;
using Nop.Plugin.Widgets.NopQuickTabs.Models;
using Nop.Plugin.Widgets.NopQuickTabs.Services;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.NopQuickTabs.Factories;
public class TabHomeModelFactory : ITabHomeModelFactory
{
    private readonly ITabService _tabService;
    public TabHomeModelFactory(ITabService tabService)
    {
        _tabService = tabService;
    }
    public async Task<TabHomeModel> PrepareTabUIModelAsync(Tab entity)
    {
        var tabHomeModel = new TabHomeModel();
        tabHomeModel.Title = entity.Title;
        tabHomeModel.Description = entity.Description;
        tabHomeModel.ContentType = entity.ContentType;
        tabHomeModel.IsActive = entity.IsActive;
        tabHomeModel.DisplayOrder = entity.DisplayOrder;
        tabHomeModel.Id = entity.Id;
        return tabHomeModel;
    }

    public async Task<TabUIModel> PrepareTabUIModelListAsync(int productId, ProductDetailsModel productModel)
    {
        var tabList = await _tabService.GetProductTabList(productId);

        var tabUIModel = new TabUIModel();
        tabUIModel.ProductModel = productModel;
        tabUIModel.ProductId = productId;

        if (tabList.Count == 0)
            return tabUIModel;

        foreach (var item in tabList)
        {
            var model = await PrepareTabUIModelAsync(item);

            tabUIModel.TabHomeModel.Add(model);
        }

        return tabUIModel;


    }
}
