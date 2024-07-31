using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
public partial record ShareOptionSearchModel : BaseSearchModel
{
    public ShareOptionSearchModel()
    {
        WidgetZoneList = WidgetZoneHelper.GetAllWidgetZone();
        AddShareOptionModel = new ShareOptionModel();
    }
    public int ShareMediaId { get; set; }
    public string CustomMessage { get; set; }
    public bool IncludedLink { get; set; }
    public string zone { get; set; }
    public IList<SelectListItem> WidgetZoneList { get; set; }

    public ShareOptionModel AddShareOptionModel { get; set; }


}
