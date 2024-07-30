using System.Web;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.SocialMediaSharing.Models;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Components;
public class SocialMediaSharingViewComponent : NopViewComponent
{


    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {

        var currentUrl = Request.Path; // Get the current URL
        var encodedUrl = HttpUtility.UrlEncode(currentUrl); // URL encode the current URL

        var model = new SocialMediaShareModel
        {
            FacebookUrl = "https://www.facebook.com/sharer/sharer.php?u=" + encodedUrl,
            TwitterUrl = "https://twitter.com/share?url=" + encodedUrl,
            LinkedInUrl = "https://www.linkedin.com/shareArticle?mini=true&url=" + encodedUrl,
            MessengerUrl = "fb-messenger://share?link=" + encodedUrl,
            WhatsAppUrl = "https://api.whatsapp.com/send?text=" + encodedUrl
        };


        return View("~/Plugins/Widgets.SocialMediaSharing/Views/Shared/Components/SocialMediaSharing/Default.cshtml");
    }


}
