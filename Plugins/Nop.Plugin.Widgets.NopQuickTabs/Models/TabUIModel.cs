using Nop.Web.Framework.Models;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.NopQuickTabs.Models;
public record TabUIModel : BaseNopEntityModel
{
    public TabUIModel()
    {
        ProductModel = new ProductDetailsModel();
        TabHomeModel = new List<TabHomeModel>();
    }

    public int ProductId { get; set; }
    public ProductDetailsModel ProductModel { get; set; }

    public IList<TabHomeModel> TabHomeModel { get; set; }


}
