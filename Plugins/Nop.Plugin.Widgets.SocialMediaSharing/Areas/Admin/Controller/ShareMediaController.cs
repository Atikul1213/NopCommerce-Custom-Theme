﻿using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.MediaFolder;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;
using Nop.Services.Media;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Controller;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class ShareMediaController : BasePluginController
{
    private readonly IShareMediaModelFactory _shareMediaModelFactory;
    private readonly IShareMediaService _shareMediaService;
    private readonly IPictureService _pictureService;
    private readonly IShareOptionModelFactory _shareOptionModelFactory;
    private readonly IShareOptionService _shareOptionService;

    #region Ctor
    public ShareMediaController(IShareMediaModelFactory shareMediaModelFactory, IShareMediaService shareMediaService, IPictureService pictureService, IShareOptionModelFactory shareOptionModelFactory, IShareOptionService shareOptionService)
    {
        _shareMediaModelFactory = shareMediaModelFactory;
        _shareMediaService = shareMediaService;
        _pictureService = pictureService;
        _shareOptionModelFactory = shareOptionModelFactory;
        _shareOptionService = shareOptionService;
    }

    #endregion


    #region Method 
    public async Task<IActionResult> List()
    {

        var searchModel = await _shareMediaModelFactory.PrepareShareMediaSearchModelAsync(new ShareMediaSearchModel());

        return View("List", searchModel);
        //return View("~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/ShareMedia/List.cshtml", searchModel);
    }

    [HttpPost]
    public async Task<IActionResult> List(ShareMediaSearchModel searchModel)
    {

        var model = await _shareMediaModelFactory.PrepareShareMediaListModelAsync(searchModel);

        return Json(model);
    }

    public async Task<IActionResult> Create()
    {

        var model = new ShareMediaModel();
        return View("Create", model);
        // return View("~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/ShareMedia/Create.cshtml",model);
    }



    protected virtual async Task UpdatePictureSeoNameAsync(ShareMedia media)
    {
        var picture = await _pictureService.GetPictureByIdAsync(media.IconId);

        if (picture != null)
            await _pictureService.SetSeoFilenameAsync(picture.Id, await _pictureService.GetPictureSeNameAsync(media.Name));
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Create(ShareMediaModel obj, bool continueEditing)
    {
        if (ModelState.IsValid)
        {
            var model = new ShareMedia();

            model = await _shareMediaModelFactory.PrepareShareMediaAsync(obj);

            await _shareMediaService.InsertShareMediaAsync(model);

            await UpdatePictureSeoNameAsync(model);


            return continueEditing ? RedirectToAction("Edit", new { id = model.Id }) : RedirectToAction("List");
        }

        return RedirectToAction("List");
    }


    public async Task<IActionResult> Edit(int id)
    {
        var shareMedia = await _shareMediaService.GetShareMediaByIdAsync(id);

        if (shareMedia == null)
            return RedirectToAction("List");
        var obj = new ShareMediaModel();

        var model = await _shareMediaModelFactory.PrepareShareMediaModelAsync(obj, shareMedia);

        return View("Edit", model);
        //return View("~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/ShareMedia/Edit.cshtml",model);
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Edit(ShareMediaModel model, bool continueEditing)
    {
        var shareMedia = await _shareMediaService.GetShareMediaByIdAsync(model.Id);

        if (shareMedia == null)

            return RedirectToAction("List");

        if (ModelState.IsValid)
        {
            var obj = new ShareMedia();
            obj = await _shareMediaModelFactory.PrepareShareMediaAsync(model);

            await _shareMediaService.UpdateShareMediaAsync(obj);

            return continueEditing ? RedirectToAction("Edit", new { id = obj.Id }) : RedirectToAction("List");
        }

        return RedirectToAction("List");
    }




    [HttpPost]
    public async Task<IActionResult> Delete(ShareMediaModel model)
    {
        var shareMedia = await _shareMediaService.GetShareMediaByIdAsync(model.Id);

        if (shareMedia == null)
            return RedirectToAction("List");

        await _shareMediaService.DeleteShareMediaAsync(shareMedia);

        return RedirectToAction("List");
    }




    [HttpPost]

    public async Task<IActionResult> DeleteSelected(ICollection<int> selectedId)
    {
        if (selectedId == null || selectedId.Count == 0)
            return NoContent();

        try
        {
            foreach (var id in selectedId)
            {
                var media = await _shareMediaService.GetShareMediaByIdAsync(id);
                if (media != null)
                {
                    await _shareMediaService.DeleteShareMediaAsync(media);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        return Json(new { Result = true });
    }



    #endregion




    #region Jquery

    [HttpPost]
    public virtual async Task<IActionResult> ShareOptionList(ShareOptionSearchModel searchModel)
    {
        var entity = await _shareMediaService.GetShareMediaByIdAsync(searchModel.ShareMediaId);

        var model = await _shareOptionModelFactory.PrepareShareOptionListModelAsync(searchModel, entity);

        return Json(model);

    }


    [HttpPost]
    public virtual async Task<IActionResult> ShareOptionAdd(int shareMediaId, [Validate] ShareOptionModel model)
    {

        if (!ModelState.IsValid)
        {
            return ErrorJson(ModelState.SerializeErrors());
        }

        var res = await _shareOptionModelFactory.PrepareShareOptionAsync(model);
        await _shareOptionService.InsertShareOptionAsync(res);

        return Json(new { Result = true });
    }


    [HttpPost]
    public virtual async Task<IActionResult> ShareOptionUpdate([Validate] ShareOptionModel model)
    {
        if (!ModelState.IsValid)
        {
            return ErrorJson(ModelState.SerializeErrors());
        }

        var shareOption = await _shareOptionService.GetShareOptionByIdAsync(model.Id);

        if (shareOption == null)
            throw new ArgumentException("Error occur when you tried to edit", nameof(model.Id));

        var obj = new ShareOption();
        model.ShareMediaId = shareOption.ShareMediaId;
        obj.Id = shareOption.Id;

        obj = await _shareOptionModelFactory.PrepareShareOptionAsync(model);
        obj.Id = shareOption.Id;

        await _shareOptionService.UpdateShareOptionAsync(obj);

        return new NullJsonResult();
    }


    [HttpPost]
    public virtual async Task<IActionResult> ShareOptionDelete(int id)
    {

        var shareOption = await _shareOptionService.GetShareOptionByIdAsync(id);

        if (shareOption == null)
            throw new ArgumentException("No resource found with the specified id", nameof(id));

        await _shareOptionService.DeleteShareOptionAsync(shareOption);

        return new NullJsonResult();
    }


    #endregion





}
