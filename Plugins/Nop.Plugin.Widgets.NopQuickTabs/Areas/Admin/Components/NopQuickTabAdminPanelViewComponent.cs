using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Components;
public class NopQuickTabAdminPanelViewComponent : NopViewComponent
{
    private readonly ITabModelFactorie _tabModelFactorie;
    public NopQuickTabAdminPanelViewComponent(ITabModelFactorie tabModelFactorie)
    {
        _tabModelFactorie = tabModelFactorie;
    }

    public async Task<IViewComponentResult> InvokeAsync(ProductModel additionalData)
    {
        var model = new TabModel();
        //model = await _tabModelFactorie.PrepareTabModelAsync(model, new Tab());
        model.ProductId = additionalData.Id;

        return View("NopQuickTabs", model);
    }

}
