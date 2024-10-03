using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.Ecommerce.Models.ProductBrochure;
public record ProductBrochureInfoListModel : BaseNopEntityModel
{
    public ProductBrochureInfoListModel()
    {
        ProductBrochures = new List<ProductBrochureInfoModel>();
    }
    public IList<ProductBrochureInfoModel> ProductBrochures { get; set; }
}
