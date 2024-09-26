using Nop.Core;
using Nop.Plugin.Widgets.Ecommerce.Domains;

namespace Nop.Plugin.Widgets.Ecommerce.Services.ProductBrochureAttach;
public interface IProductBrochureService
{
    Task InsertProductBrochureAsync(ProductBrochure productBrochure);

    Task DeleteProductBrochureAsync(ProductBrochure productBrochure);

    Task UpdateProductBrochureAsync(ProductBrochure productBrochure);

    Task<ProductBrochure> GetProductBrochureByIdAsync(int id);

    Task<ProductBrochure> GetProductBrochureByProductIdAsync(int productId);

    Task<IList<ProductBrochure>> GetProductBrochuresListByProductIdAsync(int productId);

    Task<IPagedList<ProductBrochure>> SearchProductBrochureAsync(int productId, int pageIndex = 0, int pageSize = int.MaxValue);
}
