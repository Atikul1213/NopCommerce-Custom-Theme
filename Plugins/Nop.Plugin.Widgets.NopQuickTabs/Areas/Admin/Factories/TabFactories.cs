using Nop.Plugin.Widgets.NopQuickTabs.Services;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
public class TabFactories : ITabFactories
{
    private readonly ITabService _tabService;
    public TabFactories(ITabService tabService)
    {
        _tabService = tabService;
    }


}
