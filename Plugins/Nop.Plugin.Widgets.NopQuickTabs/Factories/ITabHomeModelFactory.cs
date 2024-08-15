using Nop.Plugin.Widgets.NopQuickTabs.Domains;
using Nop.Plugin.Widgets.NopQuickTabs.Models;

namespace Nop.Plugin.Widgets.NopQuickTabs.Factories;
public interface ITabHomeModelFactory
{
    Task<TabUIModel> PrepareTabUIModelAsync(Tab entity);

    Task<IList<TabUIModel>> PrepareTabUIModelListAsync(int productId);

}
