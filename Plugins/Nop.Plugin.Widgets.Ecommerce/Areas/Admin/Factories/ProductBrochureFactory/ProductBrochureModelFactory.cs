using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure;
using Nop.Plugin.Widgets.Ecommerce.Domains;
using Nop.Plugin.Widgets.Ecommerce.Services.ProductBrochureAttach;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.ProductBrochureFactory;
public class ProductBrochureModelFactory : IProductBrochureModelFactory
{
    #region Fields

    private readonly IProductBrochureService _productBrochureService;

    #endregion

    #region Ctor
    public ProductBrochureModelFactory(IProductBrochureService productBrochureService)
    {
        _productBrochureService = productBrochureService;
    }

    #endregion


    #region Method

    public async Task<ProductBrochureModel> PrepareProductBrochureModelAsync(ProductBrochureModel model, ProductBrochure productBrochure, bool excludeProperties)
    {

        if (productBrochure != null)
        {
            model = productBrochure.ToModel<ProductBrochureModel>();
        }

        return model;
    }

    public async Task<ProductBrochureListModel> PrepareProductBrochureListModelAsync(ProductBrochureSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(nameof(searchModel));

        var productBrochures = await _productBrochureService.SearchProductBrochureAsync(searchModel.ProductId,
                               pageIndex: searchModel.Page - 1,
                               pageSize: searchModel.PageSize);

        var model = await new ProductBrochureListModel().PrepareToGridAsync(searchModel, productBrochures, () =>
        {
            return productBrochures.SelectAwait(async productBrochure =>
            {
                return await PrepareProductBrochureModelAsync(null, productBrochure, true);
            });
        });

        return model;

    }


    public async Task<ProductBrochureSearchModel> PrepareProductBrochureSearchModelAsync(ProductBrochureSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);
        searchModel.SetGridPageSize();
        return searchModel;
    }


    #endregion
}
