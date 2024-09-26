using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Demo.Components;
public class DemoViewComponent : NopViewComponent
{



    public async Task<IViewComponentResult> InvokeAsync(string widgetZone)
    {


        return View("Default");
    }
}
