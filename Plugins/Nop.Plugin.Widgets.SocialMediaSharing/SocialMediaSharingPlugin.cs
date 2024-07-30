using Nop.Core;
using Nop.Plugin.Widgets.SocialMediaSharing.Components;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;


namespace Nop.Plugin.Widgets.SocialMediaSharing
{
    public class SocialMediaSharingPlugin : BasePlugin, IWidgetPlugin
    {
        public bool HideInWidgetList => false;


        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
   
        public SocialMediaSharingPlugin(IWebHelper webHelper, ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

    


        public Type GetWidgetViewComponent(string widgetZone)
        {
            //  if (widgetZone == PublicWidgetZones.HomepageTop)
            //  {
            return typeof(SocialMediaSharingViewComponent);
            //}
        }


        public async Task<IList<string>> GetWidgetZonesAsync()
        {
            var widgetZones = new List<string>
        {
            PublicWidgetZones.HomepageTop,
            // Add more widget zones if needed
        };
            return await Task.FromResult(widgetZones);
        }


        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/ShareMedia/List";
        }



        public override async Task InstallAsync()
        {

            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Admin.Widget.SocialMediaSharing.Model.Name"] = "Media Name",
                ["Admin.Widget.SocialMediaSharing.Model.Url"] = "Url",
                ["Admin.Widget.SocialMediaSharing.Model.DisplayOrder"] = "DisplayOrder",
                ["Admin.Widget.SocialMediaSharing.Model.IsActive"] = "IsActive",
                ["Admin.Widget.SocialMediaSharing.Model.IconId"] = "IconId",
                ["Admin.Widget.ShareMedia.AddNew"] = "AddNew",
                ["Admin.Widget.ShareMedia.BackToList"] = "BackToList",

            });

            await base.InstallAsync();
        }


        public override Task UninstallAsync() { 
            return base.UninstallAsync(); 
        }

      
    }

}
