using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Components;
public class NopQuickTabAdminPanelComponent : NopViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ProductModel additionalData)
    {
        var model = new TabModel();
        model.ProductId = additionalData.Id;
        model.TabOptionModel.ProductId = additionalData.Id;
        return View("~/Plugins/Widgets.NopQuickTabs/Areas/Admin/Views/Components/NopQuickTabAdminPanel/_NopQuickTabs.cshtml", model);
    }

}
