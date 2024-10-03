using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
public record ShareOptionModel : BaseNopEntityModel
{
    public ShareOptionModel()
    {
       WidgetZoneList = WidgetZoneHelper.GetAllWidgetZone();
    }

    public int ShareMediaId { get; set; }

    [NopResourceDisplayName("Admin.ShareMediaOption.ShareOption.Fields.CustomMessage")]
    public string CustomMessage { get; set; }
    [NopResourceDisplayName("Admin.ShareMediaOption.ShareOption.Fields.zone")]
    public string Zone { get; set; }
    public IList<SelectListItem> WidgetZoneList { get; set; }


}
