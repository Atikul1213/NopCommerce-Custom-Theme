using Nop.Core;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Components;
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
            if (widgetZone == "productdetails_bottom")
                return typeof(NopQuickTabsPublicViewComponents);
            else

                return typeof(NopQuickTabAdminPanelComponent);
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {


            return Task.FromResult<IList<string>>(
                new List<string>
                {
                    PublicWidgetZones.ProductDetailsBottom,
                    AdminWidgetZones.ProductDetailsBlock
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
                ["Admin.Common.AddNewRecord"] = "AddNewTab",

                ["Admin.Widget.NopQuickTab.Field.ProductId"] = "ProductId",
                ["Admin.Widget.NopQuickTab.Field.Title"] = "Title",
                ["Admin.Widget.NopQuickTab.Field.Title.Hint"] = "The title of the Tab",
                ["Admin.Widget.NopQuickTab.Field.Description"] = "Description",
                ["Admin.Widget.NopQuickTab.Field.Description.Hint"] = "The Description is the text that is show in the Product page",
                ["Admin.Widget.NopQuickTab.Field.DisplayOrder"] = "Display Order",
                ["Admin.Widget.NopQuickTab.Field.DisplayOrder.Hint"] = "Display Order of the Tab",
                ["Admin.Widget.NopQuickTab.Field.IsActive"] = "IsActive",
                ["Admin.Widget.NopQuickTab.Field.IsActive.Hint"] = "Check to IsActive the Tab in the Product Page",
                ["Admin.Widget.NopQuickTab.Field.ContentType"] = "Content Type",
                ["Admin.Widget.NopQuickTab.Field.ContentType.Hint"] = "Choose a Content Type"

            });


            await base.InstallAsync();
        }


        public override async Task UninstallAsync()
        {
            await base.UninstallAsync();
        }



    }
}
