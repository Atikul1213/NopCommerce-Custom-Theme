using Nop.Core;
using Nop.Plugin.Widgets.NopQuickTabs.Components;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.NopQuickTabs
{
    public class NopQuickTabsPlugin : BasePlugin, IWidgetPlugin
    {
        public bool HideInWidgetList => false;

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
        public NopQuickTabsPlugin(IWebHelper webHelper, ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }


        public override string GetConfigurationPageUrl()
        {


            return _webHelper.GetStoreLocation() + "Admin/Tab/Create";
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

            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["NopQuickTabs.Admin.NopProductsTabTitle"] = "Tabs",
                ["NopQuickTabs.Admin.NopProductsTabTitle.AddNewTab"] = "AddNewTab",
                ["NopQuickTabs.Admin.NopProductsTabTitle.ProductSpecificTabs"] = "Product specific tabs",
                ["Admin.Widget.Tab.BackToList"] = "BackToList",

                ["Admin.Widget.NopQuickTab.Field.ProductId"] = "ProductId",
                ["Admin.Widget.NopQuickTab.Field.Title"] = "Title",
                ["Admin.Widget.NopQuickTab.Field.Description"] = "Description",
                ["Admin.Widget.NopQuickTab.Field.DisplayOrder"] = "Display Order",
                ["Admin.Widget.NopQuickTab.Field.IsActive"] = "IsActive",
                ["Admin.Widget.NopQuickTab.Field.ContentType"] = "Content Type"

            });


            await base.InstallAsync();
        }


        public override async Task UninstallAsync()
        {
            await base.UninstallAsync();
        }



    }
}
