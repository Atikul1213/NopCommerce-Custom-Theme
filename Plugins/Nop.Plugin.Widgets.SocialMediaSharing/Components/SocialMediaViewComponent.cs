using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.SocialMediaSharing.Factories;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Components;
public class SocialMediaViewComponent : NopViewComponent
{
    private readonly IShareMediaService _shareMediaService;
    private readonly ISocialMediaHomeModelFactory _socialMediaHomeModelFactory;
    public SocialMediaViewComponent(IShareMediaService shareMediaService, ISocialMediaHomeModelFactory socialMediaHomeModelFactory)
    {
        _shareMediaService = shareMediaService;
        _socialMediaHomeModelFactory = socialMediaHomeModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {

        var shareMedia = await _shareMediaService.GetAllShareMediaAsync();

        shareMedia = shareMedia.Where(x=>x.IsActive==true).ToList();

        if (!shareMedia.Any())
            return Content("");

        var model = await _socialMediaHomeModelFactory.PrepareSocialMediaListModelAsync(shareMedia, widgetZone);

        if (model == null)
            return Content("");

        return View("~/Plugins/Widgets.SocialMediaSharing/Views/Shared/Components/SocialMediaView/Default.cshtml",model);
    }

     

}
