using Nop.Core;
using Nop.Plugin.Widgets.NopQuickTabs.Components;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.NopQuickTabs
{
    public class NopQuickTabsPlugin : BasePlugin, IWidgetPlugin
    {
        public bool HideInWidgetList => false;

        private readonly IWebHelper _webHelper;
        public NopQuickTabsPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }


        public Type GetWidgetViewComponent(string widgetZone)
        {

            return typeof(NopQuickTabsViewComponents);
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {

            return Task.FromResult<IList<string>>(
                new List<string>
                {
                    PublicWidgetZones.HomepageTop,
                });

        }


        public override async Task InstallAsync()
        {

            await base.InstallAsync();
        }


        public override async Task UninstallAsync()
        {
            await base.UninstallAsync();
        }



    }
}
