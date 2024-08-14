using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;
using Nop.Plugin.Widgets.NopQuickTabs.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Controller;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class TabController : BasePluginController
{
    private readonly ITabService _tabService;
    private readonly ITabFactories _tabFactories;
    public TabController(ITabService tabService, ITabFactories tabFactories)
    {
        _tabService = tabService;
        _tabFactories = tabFactories;




    }


    public async Task<JsonResult> ListProductSpecificTabs(TabSearchModel searchModel, int productId)
    {
        var model = await _tabFactories.PrepareTabListModelAsync(searchModel, productId);

        return Json(model);

    }




    public async Task<IActionResult> Create(int productId, bool IsPopup)
    {
        var model = new TabModel();
        model.ProductId = productId;
        return View("~/Plugins/Widgets.NopQuickTabs/Areas/Admin/Views/Tab/Create.cshtml", model);
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]

    public async Task<IActionResult> Create(TabModel model, bool continueEditing)
    {
        if (ModelState.IsValid)
        {
            var tab = new Tab();

            tab = await _tabFactories.PrepareTabAsync(model);
            await _tabService.InsertTabAsync(tab);

            return RedirectToAction("Create");
        }

        return RedirectToAction("Create");

    }




}
