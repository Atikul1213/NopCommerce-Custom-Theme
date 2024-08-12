using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
public record TabModel : BaseNopEntityModel
{
    public TabModel()
    {
        AvailableProduct = new List<SelectListItem>();
    }
    public int ProductId { get; set; }
    public string SystemName { get; set; }

    public string DisplayName { get; set; }
    public string Description { get; set; }
    public bool LimitedToStores { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsEnable { get; set; }

    public IList<SelectListItem> AvailableProduct { get; set; }


}
