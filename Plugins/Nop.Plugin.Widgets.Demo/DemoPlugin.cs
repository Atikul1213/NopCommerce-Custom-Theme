using Nop.Core;
using Nop.Plugin.Widgets.Demo.Components;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.Demo
{
    public class DemoPlugin : BasePlugin, IWidgetPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
        #endregion

        #region Ctor
        public DemoPlugin(IWebHelper webHelper, ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

        #endregion  

        #region Method

        public bool HideInWidgetList => false;

        /**
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "/Admin/CompanyAdmin/Create";
        }

        */
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


    }
}
