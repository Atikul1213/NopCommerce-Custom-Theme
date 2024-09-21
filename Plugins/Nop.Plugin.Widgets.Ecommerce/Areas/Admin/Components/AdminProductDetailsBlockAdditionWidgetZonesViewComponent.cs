using Microsoft.AspNetCore.Mvc;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Components;
public class AdminProductDetailsBlockAdditionWidgetZonesViewComponent : NopViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        if (additionalData is not ProductModel model)
            return Content("");

        if (model.Id <= 0)
            return Content("");

        return View(model);
    }
}
