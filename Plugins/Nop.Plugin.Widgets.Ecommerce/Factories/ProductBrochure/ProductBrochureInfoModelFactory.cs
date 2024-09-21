using Nop.Plugin.Widgets.Ecommerce.Models.ProductBrochure;
using Nop.Plugin.Widgets.Ecommerce.Services.ProductBrochureAttach;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;

namespace Nop.Plugin.Widgets.Ecommerce.Factories.ProductBrochure;
public class ProductBrochureInfoModelFactory : IProductBrochureInfoModelFactory
{
    #region Fields

    private readonly IProductBrochureService _productBrochureService;
    private readonly IDownloadService _downloadService;

    #endregion

    #region Ctor
    public ProductBrochureInfoModelFactory(IProductBrochureService productBrochureService, IDownloadService downloadService)
    {
        _productBrochureService = productBrochureService;
        _downloadService = downloadService;
    }

    #endregion

    #region Methods

    public virtual async Task<ProductBrochureInfoListModel> PrepareProductBrochureInfoListModelAsync(int productId)
    {
        var productBrochures = await _productBrochureService.GetProductBrochuresListByProductIdAsync(productId);

        var model = new ProductBrochureInfoListModel();

        if (productBrochures.Count == 0)
            return model;

        foreach (var productBrochure in productBrochures)
        {
            var productBrochureInfoModel = productBrochure.ToModel<ProductBrochureInfoModel>();
            productBrochureInfoModel.DownloadGuid = (await _downloadService.GetDownloadByIdAsync(productBrochure.ProductDownloadId))?.DownloadGuid ?? Guid.Empty;

            model.ProductBrochures.Add(productBrochureInfoModel);
        }

        return model;
    }

    #endregion
}
