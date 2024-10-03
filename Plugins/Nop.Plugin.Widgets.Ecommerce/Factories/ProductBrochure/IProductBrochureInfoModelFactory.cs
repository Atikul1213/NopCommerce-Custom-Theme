using Nop.Plugin.Widgets.Ecommerce.Models.ProductBrochure;

namespace Nop.Plugin.Widgets.Ecommerce.Factories.ProductBrochure;
public interface IProductBrochureInfoModelFactory
{
    Task<ProductBrochureInfoListModel> PrepareProductBrochureInfoListModelAsync(int productId);
}
