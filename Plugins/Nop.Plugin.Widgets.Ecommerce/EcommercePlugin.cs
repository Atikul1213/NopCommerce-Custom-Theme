using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Plugin.Widgets.Ecommerce.Components;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.Ecommerce
{
    public class EcommercePlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor
        public EcommercePlugin(IWebHelper webHelper, ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

        #endregion  

        #region Method

        public bool HideInWidgetList => false;


        public override string GetConfigurationPageUrl()
        {

            return _webHelper.GetStoreLocation() + "Admin/EcommerceCompany/Create";
        }


        #endregion

        #region WidgetZone
        public Type GetWidgetViewComponent(string widgetZone)
        {
            //  if (widgetZone == PublicWidgetZones.HomepageTop)
            //  {
            return typeof(DemoViewComponent);
            //}
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(
                new List<string>
                {
                PublicWidgetZones.HomepageTop,
                });
        }

        #endregion


        #region Install
        public override async Task InstallAsync()
        {

            //locales
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {


            });
            await base.InstallAsync();
        }

        #endregion


        #region Uninstall
        public override async Task UninstallAsync()
        {

            await base.UninstallAsync();
        }

        #endregion




        #region SiteMap

        public Task ManageSiteMapAsync(SiteMapNode rootNode)
        {
            // Create the parent node for your plugin
            var companyManagerMenuItem = new SiteMapNode
            {
                SystemName = "CompanyManager",
                Title = "Company Manager",
                ControllerName = "EcommerceCompany",
                ActionName = "List",
                IconClass = "far fa-dot-circle",
                Visible = true,
                RouteValues = new RouteValueDictionary { { "area", AreaNames.ADMIN } },
            };

            // Add the parent node to the root site map
            rootNode.ChildNodes.Add(companyManagerMenuItem);

            // Create a sub-menu item under the parent node
            var addCompanySubmenuItem = new SiteMapNode
            {
                SystemName = "CompanyManager.Create",
                Title = "Add new company",
                ControllerName = "EcommerceCompany",
                ActionName = "Create",
                IconClass = "far fa-dot-circle",
                Visible = true,
                RouteValues = new RouteValueDictionary { { "area", AreaNames.ADMIN } },
            };

            // Add the sub-menu item to the parent node
            companyManagerMenuItem.ChildNodes.Add(addCompanySubmenuItem);

            return Task.CompletedTask;
        }

        #endregion

    }
}
