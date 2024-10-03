using Nop.Core;
using Nop.Data;
using Nop.Plugin.Widgets.Ecommerce.Domains;

namespace Nop.Plugin.Widgets.Ecommerce.Services.ProductBrochureAttach;
public class ProductBrochureService : IProductBrochureService
{
    #region Fields

    private readonly IRepository<ProductBrochure> _productBrochurerepository;

    #endregion

    #region Ctor

    public ProductBrochureService(IRepository<ProductBrochure> productBrochurerepository)
    {
        _productBrochurerepository = productBrochurerepository;
    }

    #endregion

    #region Methods

    public virtual async Task InsertProductBrochureAsync(ProductBrochure productBrochure)
    {
        await _productBrochurerepository.InsertAsync(productBrochure);
    }

    public virtual async Task UpdateProductBrochureAsync(ProductBrochure productBrochure)
    {
        await _productBrochurerepository.UpdateAsync(productBrochure);
    }
    public virtual async Task DeleteProductBrochureAsync(ProductBrochure productBrochure)
    {
        await _productBrochurerepository.DeleteAsync(productBrochure);
    }

    public virtual async Task<ProductBrochure> GetProductBrochureByIdAsync(int id)
    {
        return await _productBrochurerepository.GetByIdAsync(id);
    }

    public virtual async Task<ProductBrochure> GetProductBrochureByProductIdAsync(int productId)
    {
        return await _productBrochurerepository.Table.FirstOrDefaultAsync(x => x.ProductId == productId);
    }

    public async Task<IList<ProductBrochure>> GetProductBrochuresListByProductIdAsync(int productId)
    {
        var query = await (from pb in _productBrochurerepository.Table
                           where pb.ProductId == productId
                           orderby pb.DisplayOrder
                           select pb).ToListAsync();
        return query;
    }

    public virtual async Task<IPagedList<ProductBrochure>> SearchProductBrochureAsync(int productId, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var query = from pb in _productBrochurerepository.Table
                    select pb;
        if (productId > 0)
            query = query.Where(x => x.ProductId == productId);

        query = query.OrderBy(x => x.DisplayOrder);

        return await query.ToPagedListAsync(pageIndex, pageSize);
    }

    #endregion
}
