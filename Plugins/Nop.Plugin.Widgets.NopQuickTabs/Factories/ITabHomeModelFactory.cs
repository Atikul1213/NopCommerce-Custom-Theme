using Nop.Plugin.Widgets.NopQuickTabs.Domains;
using Nop.Plugin.Widgets.NopQuickTabs.Models;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.NopQuickTabs.Factories;
public interface ITabHomeModelFactory
{
    Task<TabHomeModel> PrepareTabUIModelAsync(Tab entity);

    Task<TabUIModel> PrepareTabUIModelListAsync(int productId, ProductDetailsModel productModel);

}
