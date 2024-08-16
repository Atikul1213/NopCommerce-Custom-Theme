using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.NopQuickTabs.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Services;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.NopQuickTabs.Components;
public class NopQuickTabsPublicViewComponent : NopViewComponent
{
    private readonly ITabService _tabService;
    private readonly ITabHomeModelFactory _tabHomeModelFactory;
    public NopQuickTabsPublicViewComponent(ITabService tabService, ITabHomeModelFactory tabHomeModelFactory)
    {
        _tabService = tabService;
        _tabHomeModelFactory = tabHomeModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, ProductDetailsModel additionalData)
    {


        var model = await _tabHomeModelFactory.PrepareTabUIModelListAsync(additionalData.Id, additionalData);
        if (model == null || model.TabHomeModel.Count == 0)
            return Content("");

        return View("Default", model);
    }

}
