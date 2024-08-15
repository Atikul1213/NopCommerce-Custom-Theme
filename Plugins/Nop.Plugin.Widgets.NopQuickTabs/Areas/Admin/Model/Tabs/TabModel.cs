using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
public record TabModel : BaseNopEntityModel
{
    public TabModel()
    {
        TabOptionModel = new TabOptionModel();
    }
    [NopResourceDisplayName("Admin.Widget.NopQuickTab.Field.ProductId")]
    public int ProductId { get; set; }
    [NopResourceDisplayName("Admin.Widget.NopQuickTab.Field.Title")]
    public string Title { get; set; }
    [NopResourceDisplayName("Admin.Widget.NopQuickTab.Field.Description")]
    public string Description { get; set; }
    [NopResourceDisplayName("Admin.Widget.NopQuickTab.Field.DisplayOrder")]
    public int DisplayOrder { get; set; }
    [NopResourceDisplayName("Admin.Widget.NopQuickTab.Field.IsActive")]
    public bool IsActive { get; set; }
    [NopResourceDisplayName("Admin.Widget.NopQuickTab.Field.ContentType")]
    public string ContentType { get; set; }
    public TabOptionModel TabOptionModel { get; set; }

}
