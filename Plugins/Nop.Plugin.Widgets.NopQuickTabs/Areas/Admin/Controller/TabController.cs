using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Model.Tabs;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;
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
    private readonly ITabModelFactorie _tabModelFactorie;
    public TabController(ITabService tabService, ITabModelFactorie tabModelFactorie)
    {
        _tabService = tabService;
        _tabModelFactorie = tabModelFactorie;

    }

    #region Jquery

    public async Task<JsonResult> ListProductSpecificTabs(TabSearchModel searchModel, int productId)
    {

        //var src = await _tabModelFactorie.PrepareTabSearchModelAsync(searchModel);

        var model = await _tabModelFactorie.PrepareTabListModelAsync(searchModel, productId);

        return Json(model);

    }



    [HttpPost]
    public virtual async Task<IActionResult> TabOptionAdd(int productId, [Validate] TabModel model)
    {
        if (!ModelState.IsValid)
        {
            return ErrorJson(ModelState.SerializeErrors());
        }


        var tab = await _tabModelFactorie.PrepareTabAsync(model);
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

        var tab = await _tabModelFactorie.PrepareTabDataTableAsync(model);
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

    #endregion


    #region Create

    public async Task<IActionResult> Create(int productId, bool IsPopup)
    {
        var model = new TabModel();

        model = await _tabModelFactorie.PrepareTabModelAsync(model, new Tab());
        model.ProductId = productId;
        return View("Create", model);
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Create(TabModel model, bool continueEditing)
    {
        if (ModelState.IsValid)
        {
            var tab = new Tab();

            tab = await _tabModelFactorie.PrepareTabAsync(model);
            await _tabService.InsertTabAsync(tab);

            await _tabModelFactorie.UpdateLocalesAsync(tab, model);

            return continueEditing ? RedirectToAction("TabEditPopup", new { id = tab.Id }) : RedirectToAction("Create", model);
            //return RedirectToAction("Create");
        }

        return RedirectToAction("Create", model);

    }

    #endregion



    #region Edit
    public virtual async Task<IActionResult> TabEditPopup(int id)
    {
        var entity = await _tabService.GetTabByIdAsync(id);

        var model = await _tabModelFactorie.PrepareTabModelAsync(new TabModel(), entity);

        if (Enum.TryParse(typeof(ContentTypes), model.ContentType, out var contentTypeEnum))
        {
            model.ContentType = ((int)(ContentTypes)contentTypeEnum).ToString();
        }

        return View("TabEditPopup", model);

    }


    [HttpPost]

    public virtual async Task<IActionResult> TabEditPopup(TabModel model)
    {


        if (ModelState.IsValid)
        {
            var tab = new Tab();

            tab = await _tabModelFactorie.PrepareTabAsync(model);
            tab.Id = model.Id;
            await _tabService.UpdateTabAsync(tab);

            await _tabModelFactorie.UpdateLocalesAsync(tab, model);

            return RedirectToAction("Create");
        }

        return RedirectToAction("Create");

    }

    #endregion






}
