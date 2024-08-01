using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
public record ShareOptionModel : BaseNopEntityModel
{
    public ShareOptionModel()
    {
       // WidgetZoneList = new List<SelectListItem>();
       WidgetZoneList = WidgetZoneHelper.GetAllWidgetZone();

    }

    public int ShareMediaId { get; set; }

    [NopResourceDisplayName("Admin.ShareMediaOption.ShareOption.Fields.CustomMessage")]
    public string CustomMessage { get; set; }
    [NopResourceDisplayName("Admin.ShareMediaOption.ShareOption.Fields.IncludedLink")]
     
    public bool IncludedLink { get; set; }
    [NopResourceDisplayName("Admin.ShareMediaOption.ShareOption.Fields.zone")]
    public string zone { get; set; }
    public IList<SelectListItem> WidgetZoneList { get; set; }


}
