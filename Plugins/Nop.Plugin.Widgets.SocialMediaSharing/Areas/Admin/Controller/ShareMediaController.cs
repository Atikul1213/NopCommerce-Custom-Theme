using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.MediaFolder;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;
using Nop.Services.Media;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Controller;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class ShareMediaController : BasePluginController
{
    private readonly IShareMediaModelFactory _shareMediaModelFactory;
    private readonly IShareMediaService _shareMediaService;
    private readonly IPictureService _pictureService;
    
    public ShareMediaController(IShareMediaModelFactory shareMediaModelFactory, IShareMediaService shareMediaService, IPictureService pictureService)
    {
        _shareMediaModelFactory = shareMediaModelFactory;
        _shareMediaService = shareMediaService;
        _pictureService = pictureService;
    }

    public async Task<IActionResult> List()
    {
        var searchModel = await _shareMediaModelFactory.PrepareShareMediaSearchModelAsync(new ShareMediaSearchModel());

        return View("~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/ShareMedia/List.cshtml", searchModel);
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
        return View("~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/ShareMedia/Create.cshtml",model);
    }



    protected virtual async Task UpdatePictureSeoNameAsync(ShareMedia media)
    {
        var picture = await _pictureService.GetPictureByIdAsync(media.IconId);
        if (picture != null)
            await _pictureService.SetSeoFilenameAsync(picture.Id, await _pictureService.GetPictureSeNameAsync(media.Name));
    }


    [HttpPost]
    public async Task<IActionResult>Create(ShareMediaModel obj)
    {
        if (ModelState.IsValid)
        {
            var model = new ShareMedia();
                
            model= await _shareMediaModelFactory.PrepareShareMediaAsync(obj);

            await _shareMediaService.InsertShareMediaAsync(model);

            await UpdatePictureSeoNameAsync(model);


            return RedirectToAction("List");  
        }

        return RedirectToAction("List");  
    }


    public async Task<IActionResult> Edit(int id)
    {
        var shareMedia = await _shareMediaService.GetShareMediaByIdAsync(id);

        if (shareMedia == null)
            return RedirectToAction("List");

        var model = await _shareMediaModelFactory.PrepareShareMediaModelAsync(shareMedia);

        return View("~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/ShareMedia/Edit.cshtml",model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ShareMediaModel model)
    {
        var shareMedia = await _shareMediaService.GetShareMediaByIdAsync(model.Id);

        if(shareMedia == null)
            return RedirectToAction("List");

        if(ModelState.IsValid)
        {
            var obj = new ShareMedia();
            obj = await _shareMediaModelFactory.PrepareShareMediaAsync(model);

            await _shareMediaService.UpdateShareMediaAsync(obj);
            return RedirectToAction("List");
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


















}
