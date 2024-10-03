using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.NopQuickTabs.Models;
public record TabHomeModel : BaseNopEntityModel
{
    public TabHomeModel()
    {

    }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
    public int ContentType { get; set; }
}
