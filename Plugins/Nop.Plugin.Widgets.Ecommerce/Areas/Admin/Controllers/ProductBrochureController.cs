using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.ProductBrochureFactory;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure;
using Nop.Plugin.Widgets.Ecommerce.Domains;
using Nop.Plugin.Widgets.Ecommerce.Services.ProductBrochureAttach;
using Nop.Services.Catalog;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Controllers;
public class ProductBrochureController : BaseAdminController
{
    #region Fields

    private readonly IPermissionService _permissionService;
    private readonly IProductBrochureService _productBrochureService;
    private readonly IDownloadService _downloadService;
    private readonly IProductService _productService;
    private readonly IProductBrochureModelFactory _productBrochureModelFactory;

    #endregion


    #region Ctor
    public ProductBrochureController(IPermissionService permissionService,
        IProductBrochureService productBrochureService,
        IProductService productService,
        IProductBrochureModelFactory productBrochureModelFactory,
        IDownloadService downloadService)
    {
        _permissionService = permissionService;
        _productBrochureService = productBrochureService;
        _downloadService = downloadService;
        _productService = productService;
        _productBrochureModelFactory = productBrochureModelFactory;
    }

    #endregion


    #region  Create ProductBrochureUpdate ProductBrochureDelete

    [HttpPost]
    public virtual async Task<IActionResult> ProductBrochureList(ProductBrochureSearchModel searchModel)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProducts))
            return await AccessDeniedDataTablesJson();

        var product = await _productService.GetProductByIdAsync(searchModel.ProductId)
           ?? throw new ArgumentException("No product found with the specified id");

        var model = await _productBrochureModelFactory.PrepareProductBrochureListModelAsync(searchModel);

        return Json(model);
    }


    [HttpPost]
    public async Task<IActionResult> Create(ProductBrochureModel model)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel))
            return AccessDeniedView();

        if (ModelState.IsValid)
        {
            var productBrochure = model.ToEntity<ProductBrochure>();
            await _productBrochureService.InsertProductBrochureAsync(productBrochure);

            return Json(new { success = true });
        }

        return Json(new { success = false, message = "Validation failed" });
    }


    [HttpPost]

    public virtual async Task<IActionResult> ProductBrochureUpdate(ProductBrochureModel model)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProducts))
            return await AccessDeniedDataTablesJson();

        var productBrochure = await _productBrochureService.GetProductBrochureByIdAsync(model.Id)
         ?? throw new ArgumentException("No product brochure found with the specified id");

        productBrochure.ButtonText = model.ButtonText;
        productBrochure.DisplayOrder = model.DisplayOrder;
        productBrochure.IsActive = model.IsActive;

        await _productBrochureService.UpdateProductBrochureAsync(productBrochure);

        return new NullJsonResult();
    }



    [HttpPost]

    public virtual async Task<IActionResult> ProductBrochureDelete(int id)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProducts))
            return await AccessDeniedDataTablesJson();

        var productBrochure = await _productBrochureService.GetProductBrochureByIdAsync(id)
            ?? throw new ArgumentException("No product brochure found with the specified id");

        var download = await _downloadService.GetDownloadByIdAsync(productBrochure.ProductDownloadId)
            ?? throw new ArgumentException("No download found with the specified id");

        await _downloadService.DeleteDownloadAsync(download);

        await _productBrochureService.DeleteProductBrochureAsync(productBrochure);

        return new NullJsonResult();
    }


    #endregion
}
