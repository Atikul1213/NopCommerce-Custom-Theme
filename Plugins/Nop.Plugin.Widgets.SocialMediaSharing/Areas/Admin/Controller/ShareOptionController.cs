using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Controller;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class ShareOptionController : BasePluginController
{
    private readonly IShareOptionModelFactory _shareOptionModelFactory;
    private readonly IShareOptionService _shareOptionService;
    public ShareOptionController(IShareOptionModelFactory shareOptionModelFactory, IShareOptionService shareOptionService)
    {
        _shareOptionService = shareOptionService;
        _shareOptionModelFactory = shareOptionModelFactory;
    }



    public async Task<IActionResult> Create()
    {
        var model = new ShareOptionModel();
        return View("~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/ShareOption/Create.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult>Create(ShareOptionModel model)
    {
        if(ModelState.IsValid)
        {
            var entity = new ShareOption();

            entity = await _shareOptionModelFactory.PrepareShareOptionAsync(model);
            await _shareOptionService.InsertShareOptionAsync(entity);
            return RedirectToAction("Create");
        }

        return RedirectToAction("Create");
    }



    public async Task<IActionResult> Edit(int id)
    {

        var entity = await _shareOptionService.GetShareOptionByIdAsync(id);
        if (entity == null)
            return RedirectToAction("Edit");

        var model = await _shareOptionModelFactory.PrepareShareOptionModelAsync(entity);

        return View("Edit", model);
    }

    [HttpPost]
    public async Task<IActionResult>Edit(ShareOptionModel model)
    {

        var entity = await _shareOptionService.GetShareOptionByIdAsync(model.Id);
        if (entity == null)
            return RedirectToAction("Edit");

        if (ModelState.IsValid)
        {
            var obj = new ShareOption();
            obj = await _shareOptionModelFactory.PrepareShareOptionAsync(model);
            await _shareOptionService.UpdateShareOptionAsync(obj);
            return RedirectToAction("Edit");
        }
        return RedirectToAction("Edit");
    }

    [HttpPost]
    public async Task<IActionResult>Delete(ShareOptionModel model)
    {
        var entity = await _shareOptionService.GetShareOptionByIdAsync(model.Id);
        if (entity == null)
            return RedirectToAction("Create");
        await _shareOptionService.DeleteShareOptionAsync(entity);
        return RedirectToAction("Create");
    }


}
