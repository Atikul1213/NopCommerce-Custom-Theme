using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
public record ShareOptionModel : BaseNopEntityModel
{
    public ShareOptionModel()
    {
       // WidgetZoneList = new List<SelectListItem>();
       WidgetZoneList = WidgetZoneHelper.GetAllWidgetZone();

    }

    public int ShareMediaId { get; set; }
    public string CustomMessage { get; set; }
    public bool IncludedLink { get; set; }
    public string zone { get; set; }
    public IList<SelectListItem> WidgetZoneList { get; set; }

   

}
