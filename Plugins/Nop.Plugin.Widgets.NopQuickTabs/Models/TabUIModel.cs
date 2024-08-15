using Nop.Web.Framework.Models;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.NopQuickTabs.Models;
public record TabUIModel : BaseNopEntityModel
{
    public TabUIModel()
    {
        ProductDetails = new ProductDetailsModel();
    }
    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
    public int ContentType { get; set; }
    public ProductDetailsModel ProductDetails { get; set; }



}
