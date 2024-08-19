using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
public interface ITabModelFactorie
{
    Task<TabModel> PrepareTabModelAsync(TabModel model, Tab entity);

    Task<Tab> PrepareTabAsync(TabModel model);

    Task<TabListModel> PrepareTabListModelAsync(TabSearchModel searchModel, int productId);

    Task<TabSearchModel> PrepareTabSearchModelAsync(TabSearchModel searchModel);

    Task<Tab> PrepareTabDataTableAsync(TabModel model);

}
