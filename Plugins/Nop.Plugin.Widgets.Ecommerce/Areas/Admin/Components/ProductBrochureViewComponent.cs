using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.ProductBrochureFactory;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Components;
public class ProductBrochureViewComponent : NopViewComponent
{
    #region Fields

    private readonly IProductBrochureModelFactory _productBrochureModelFactory;

    #endregion

    #region Ctor
    public ProductBrochureViewComponent(IProductBrochureModelFactory productBrochureModelFactory)
    {
        _productBrochureModelFactory = productBrochureModelFactory;
    }

    #endregion


    #region InvokeAsync
    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, ProductModel additionalData)
    {
        if (additionalData is not ProductModel productModel)
            return Content("");

        if (productModel.Id <= 0)
            return Content("");

        var model = new ProductBrochureModel();
        model.ProductBrochureSearchModel.ProductId = productModel.Id;

        await _productBrochureModelFactory.PrepareProductBrochureSearchModelAsync(model.ProductBrochureSearchModel);

        return View(model);
    }

    #endregion
}
