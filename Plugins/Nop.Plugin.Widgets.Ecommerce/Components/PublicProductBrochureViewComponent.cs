using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.Ecommerce.Factories.ProductBrochure;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.Ecommerce.Components;
public class PublicProductBrochureViewComponent : NopViewComponent
{
    #region Field

    private readonly IProductBrochureInfoModelFactory _productBrochureInfoModelFactory;

    #endregion

    #region Ctor
    public PublicProductBrochureViewComponent(IProductBrochureInfoModelFactory productBrochureInfoModelFactory)
    {
        _productBrochureInfoModelFactory = productBrochureInfoModelFactory;
    }

    #endregion

    #region InvokeAsync
    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, ProductDetailsModel additionalData)
    {

        if (additionalData == null || additionalData.Id <= 0)
            return Content("");

        var model = await _productBrochureInfoModelFactory.PrepareProductBrochureInfoListModelAsync(additionalData.Id);

        if (model == null || model.ProductBrochures.Count == 0)
            return Content("");

        return View(model);
    }

    #endregion
}
