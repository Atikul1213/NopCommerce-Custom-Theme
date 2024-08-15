using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.NopQuickTabs.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Services;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.NopQuickTabs.Components;
public class NopQuickTabsPublicViewComponents : NopViewComponent
{
    private readonly ITabService _tabService;
    private readonly ITabHomeModelFactory _tabHomeModelFactory;
    public NopQuickTabsPublicViewComponents(ITabService tabService, ITabHomeModelFactory tabHomeModelFactory)
    {
        _tabService = tabService;
        _tabHomeModelFactory = tabHomeModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, ProductDetailsModel additionalData)
    {


        var model = await _tabHomeModelFactory.PrepareTabUIModelListAsync(additionalData.Id, additionalData);
        if (model == null || model.TabHomeModel.Count == 0)
            return Content("");

        return View("~/Plugins/Widgets.NopQuickTabs/Views/Shared/Components/NopQuickTabsPublicView/Default.cshtml", model);
    }

}
