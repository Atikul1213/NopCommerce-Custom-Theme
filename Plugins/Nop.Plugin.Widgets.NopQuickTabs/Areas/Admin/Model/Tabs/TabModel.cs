using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
public record TabModel : BaseNopEntityModel
{
    public TabModel()
    {
        ContentTypeOptions = new List<SelectListItem>();
        LoadContentTypeOptions();
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
    public int ContentType { get; set; }

    public string ContentTypeStr { get; set; }

    public IList<SelectListItem> ContentTypeOptions { get; set; }

    private void LoadContentTypeOptions()
    {
        ContentTypeOptions = ((ContentTypes[])System.Enum.GetValues(typeof(ContentTypes)))
            .Select(ct => new SelectListItem
            {
                Value = ((int)ct).ToString(),
                Text = ct.ToString()
            }).ToList();
    }


}
