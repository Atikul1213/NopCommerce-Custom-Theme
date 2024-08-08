using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
public partial record ShareOptionSearchModel : BaseSearchModel
{
    public ShareOptionSearchModel()
    {
        WidgetZoneList = WidgetZoneHelper.GetAllWidgetZone();
        AddShareOptionModel = new ShareOptionModel();
    }
    public int ShareMediaId { get; set; }
    [NopResourceDisplayName("Admin.ShareMediaOption.ShareOption.Fields.CustomMessage")]
    public string CustomMessage { get; set; }

    [NopResourceDisplayName("Admin.ShareMediaOption.ShareOption.Fields.zone")]
    public string Zone { get; set; }
    public IList<SelectListItem> WidgetZoneList { get; set; }

    public ShareOptionModel AddShareOptionModel { get; set; }

}
