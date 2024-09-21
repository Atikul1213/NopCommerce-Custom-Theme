using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.ProductBrochureFactory;
public partial interface IProductBrochureModelFactory
{
    Task<ProductBrochureModel> PrepareProductBrochureModelAsync(ProductBrochureModel model, ProductBrochure productBrochure, bool excludeProperties);
    Task<ProductBrochureSearchModel> PrepareProductBrochureSearchModelAsync(ProductBrochureSearchModel searchModel);
    Task<ProductBrochureListModel> PrepareProductBrochureListModelAsync(ProductBrochureSearchModel searchModel);
}
