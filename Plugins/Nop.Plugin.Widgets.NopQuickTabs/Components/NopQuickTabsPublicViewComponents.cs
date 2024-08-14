using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.NopQuickTabs.Components;
public class NopQuickTabsPublicViewComponents : NopViewComponent
{

    public NopQuickTabsPublicViewComponents()
    {

    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {

        return View("~/Plugins/Widgets.NopQuickTabs/Views/Shared/Components/NopQuickTabsPublicView/Default.cshtml");
    }

}
