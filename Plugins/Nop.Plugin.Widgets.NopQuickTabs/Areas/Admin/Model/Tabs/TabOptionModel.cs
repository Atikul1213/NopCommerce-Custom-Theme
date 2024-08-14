using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
public partial record TabOptionModel : BaseSearchModel
{
    public TabOptionModel()
    {
        ContentTypeOptions = new List<SelectListItem>();
        LoadContentTypeOptions();
    }

    public int ProductId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }


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
