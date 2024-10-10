using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Menu;
using NopStation.Plugin.Misc.Core.Services;


namespace NopStation.Plugin.Widgets.AddCrawlers
{
    public class AddCrawlersPlugin : BasePlugin, IAdminMenuPlugin, INopStationPlugin
    {
        #region Properties

        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;
        private readonly INopStationCoreService _nopStationCoreService;
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctors

        public AddCrawlersPlugin(ILocalizationService localizationService,
            IWebHelper webHelper,
            INopStationCoreService nopStationCoreService,
            IPermissionService permissionService,
            IWorkContext workContext)
        {
            _localizationService = localizationService;
            _webHelper = webHelper;
            _nopStationCoreService = nopStationCoreService;
            _permissionService = permissionService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/WidgetsAddCrawlers/Configure";
        }

        public bool HideInWidgetList => false;

        public async Task ManageSiteMapAsync(SiteMapNode rootNode)
        {
            if (await _permissionService.AuthorizeAsync(AddCrawlersPermissionProvider.ManageAddCrawlers))
            {
                var menuItem = new SiteMapNode()
                {
                    Title = await _localizationService.GetResourceAsync("Plugins.Widgets.AddCrawlers.Menu.AddCrawlers"),
                    Visible = true,
                    IconClass = "far fa-dot-circle"
                };

                var configItem = new SiteMapNode()
                {
                    Title = await _localizationService.GetResourceAsync("Plugins.Widgets.AddCrawlers.Menu.Configuration"),
                    Url = "~/Admin/WidgetsAddCrawlers/Configure",
                    Visible = true,
                    IconClass = "far fa-circle",
                    SystemName = "WidgetsAddCrawlers.Configuration"
                };
                menuItem.ChildNodes.Add(configItem);

                var guestList = new SiteMapNode()
                {
                    Title = await _localizationService.GetResourceAsync("Plugins.Widgets.AddCrawlers.Menu.GuestCustomerList"),
                    Visible = true,
                    IconClass = "far fa-circle",
                    SystemName = "WidgetsAddCrawlers.GuestList",
                    ControllerName = "WidgetsAddCrawlers",
                    ActionName = "GuestList",
                    RouteValues = new RouteValueDictionary { { "area", AreaNames.ADMIN } }
                };
                menuItem.ChildNodes.Add(guestList);

                var customersItem = rootNode.ChildNodes.FirstOrDefault(node => node.SystemName.Equals("Customers"));
                if (customersItem is not null)
                {
                    var guestList2 = new SiteMapNode()
                    {
                        Title = await _localizationService.GetResourceAsync("Plugins.Widgets.AddCrawlers.Menu.GuestCustomerList"),
                        Visible = true,
                        IconClass = "far fa-dot-circle",
                        SystemName = "WidgetsAddCrawlers.GuestList",
                        ControllerName = "WidgetsAddCrawlers",
                        ActionName = "GuestList",
                        RouteValues = new RouteValueDictionary { { "area", AreaNames.ADMIN } }
                    };
                    customersItem.ChildNodes.Insert(customersItem.ChildNodes.Count, guestList2);
                }

                var crawlerList = new SiteMapNode()
                {
                    Title = await _localizationService.GetResourceAsync("Plugins.Widgets.AddCrawlers.Menu.AddCrawlersList"),
                    Visible = true,
                    IconClass = "far fa-circle",
                    SystemName = "WidgetsAddCrawlers.List",
                    ControllerName = "WidgetsAddCrawlers",
                    ActionName = "List",
                    RouteValues = new RouteValueDictionary { { "area", AreaNames.ADMIN } }
                };
                menuItem.ChildNodes.Add(crawlerList);

                await _nopStationCoreService.ManageSiteMapAsync(rootNode, menuItem, NopStation.Plugin.Misc.Core.NopStationMenuType.Plugin);
            }
        }

        public override async Task InstallAsync()
        {
            //await this.NopStationPluginInstallAsync(new AddCrawlersPermissionProvider());

            await _permissionService.InstallPermissionsAsync(new AddCrawlersPermissionProvider());

            var keyValuePairs = PluginResouces();
            foreach (var keyValuePair in keyValuePairs)
            {
                await _localizationService.AddOrUpdateLocaleResourceAsync(keyValuePair.Key, keyValuePair.Value);
            }
            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.AddCrawlers");

            //await this.NopStationPluginUninstallAsync(new AddCrawlersPermissionProvider());
            await _permissionService.UninstallPermissionsAsync(new AddCrawlersPermissionProvider());
            await base.UninstallAsync();
        }


        public List<KeyValuePair<string, string>> PluginResouces()
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Menu.AddCrawlers", "Add crawlers"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Menu.GuestCustomerList", "Online guest customers"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Menu.AddCrawlersList", "Added crawlers list"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Menu.Configuration", "Configuration"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Menu.Documentation", "Documentation"),

                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Fields.IsEnabled", "Is enabled?"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Fields.IsEnabled.Hint", "Determine is enabled or not. Enabling it will add the user agent in the admin comment"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Fields.CrawlerInfo", "Crawler info"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Fields.IPAddress", "IP address"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Fields.Location", "Location"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Fields.AddedOnUtc", "Added on"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.Fields.AddedBy", "Added by"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.AddToCrawlers", "Add crawler"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.GuestCustomers", "Online guest customers"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.error.crawlerAdd", "Failed to add crawler"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.success.crawlerAdd", "Add to crawler list successful"),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.ModalConfirmation", "Adding the Guest customer to the crawler list will not be undone."),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.LogError.AddFailed", "(AddCrawlerPlugin) Failed to add Crawler to the list."),
                new KeyValuePair<string, string>("Plugins.Widgets.AddCrawlers.error.exist", "Crawler already exist in the file"),
            };
        }


        #endregion
    }
}
