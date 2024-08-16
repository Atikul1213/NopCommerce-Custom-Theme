using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
using Nop.Plugin.Widgets.NopQuickTabs.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Validators;

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

        var src = await _tabFactories.PrepareTabSearchModelAsync(searchModel);

        var model = await _tabFactories.PrepareTabListModelAsync(searchModel, productId);

        return Json(model);

    }



    [HttpPost]
    public virtual async Task<IActionResult> TabOptionAdd(int productId, [Validate] TabModel model)
    {
        if (!ModelState.IsValid)
        {
            return ErrorJson(ModelState.SerializeErrors());
        }


        var tab = await _tabFactories.PrepareTabAsync(model);
        await _tabService.InsertTabAsync(tab);


        return Json(new { Result = true });
    }


    [HttpPost]
    public virtual async Task<IActionResult> UpdateTabs(TabModel model, int productId)
    {
        if (!ModelState.IsValid)
        {
            return ErrorJson(ModelState.SerializeErrors());
        }

        var tab = await _tabFactories.PrepareTabDataTableAsync(model);
        tab.Id = model.Id;

        await _tabService.UpdateTabAsync(tab);

        return new NullJsonResult();
    }



    [HttpPost]

    public virtual async Task<IActionResult> DeleteProductSpecificTabs(int id, int productId)
    {
        var tab = await _tabService.GetTabByIdAsync(id);
        if (tab == null)
            throw new ArgumentException("No Resource found with the specified id", nameof(id));

        await _tabService.DeleteTabAsync(tab);

        return new NullJsonResult();

    }









}
