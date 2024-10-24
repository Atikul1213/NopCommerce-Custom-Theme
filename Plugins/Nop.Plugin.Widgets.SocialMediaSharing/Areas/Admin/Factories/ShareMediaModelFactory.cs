﻿using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.MediaFolder;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
public class ShareMediaModelFactory : IShareMediaModelFactory
{
    private readonly ILocalizationService _localizationService;
    private readonly IShareMediaService _shareMediaService;
    private readonly IPictureService _pictureService;
    private readonly IShareOptionModelFactory _shareOptionModelFactory;
    public ShareMediaModelFactory(ILocalizationService localizationService, IShareMediaService shareMediaService, IPictureService pictureService, IShareOptionModelFactory shareOptionModelFactory)
    {
        _localizationService = localizationService;
        _shareMediaService = shareMediaService;
        _pictureService = pictureService;
        _shareOptionModelFactory = shareOptionModelFactory;
    }



    public async Task<ShareMedia> PrepareShareMediaAsync(ShareMediaModel model)
    {

        if (model == null)
            throw new NotImplementedException();

        var entity = new ShareMedia();

        entity = model.ToEntity(entity);

        return entity;
    }



    public async Task<ShareMediaListModel> PrepareShareMediaListModelAsync(ShareMediaSearchModel searchModel)
    {

        var shareMedialList = await _shareMediaService.SearchGetAllShareMediaAsync(pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

        var model = await new ShareMediaListModel().PrepareToGridAsync(searchModel, shareMedialList, () =>
        {
            return shareMedialList.SelectAwait(async s =>
            {
                return await PrepareShareMediaModelAsync(new ShareMediaModel(),s);
            });

        });

        return model;

    }

    public async Task<ShareMediaModel> PrepareShareMediaModelAsync(ShareMediaModel model, ShareMedia entity)
    {
         
        if (entity == null)
            throw new NotImplementedException();
 
        model = entity.ToModel(model);

        model.ShareOptionSearchModel = PrepareShareOptionSearchModel(model.ShareOptionSearchModel, entity);
        
        var picture = await _pictureService.GetPictureByIdAsync(entity.IconId);
        (model.IconThumbnailUrl, _) = await _pictureService.GetPictureUrlAsync(picture, 75);

        return model;
    }

    protected virtual ShareOptionSearchModel PrepareShareOptionSearchModel(ShareOptionSearchModel searchModel, ShareMedia media)
    {
        ArgumentNullException.ThrowIfNull(searchModel);
        ArgumentNullException.ThrowIfNull(media);
        searchModel.ShareMediaId = media.Id;
        searchModel.SetGridPageSize();

        return searchModel;
    }

    public async Task<ShareMediaSearchModel> PrepareShareMediaSearchModelAsync(ShareMediaSearchModel searchModel)
    {
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            ["Admin.Widget.SocialMediaSharing.Model.Name"] = "Media Name",
            ["Admin.Widget.SocialMediaSharing.Model.Url"] = "Url",
            ["Admin.Widget.SocialMediaSharing.Model.DisplayOrder"] = "Display Order",
            ["Admin.Widget.SocialMediaSharing.Model.IsActive"] = "IsActive",
            ["Admin.Widget.SocialMediaSharing.Model.IconId"] = "Icon",
            ["Admin.Widget.ShareMedia.AddNew"] = "AddNew",
            ["Admin.Widget.ShareMedia.BackToList"] = "BackToList",


            ["Admin.Widget.ShareMedia"] = "Share Media",
            ["Admin.Widget.SocialMediaSharing.Model.Id"] = "Edit",
            ["Admin.Widget.SocialMediaSharing.Model.Icon"] = "Icon",
            ["Admin.Widget.ShareMedia.EditDetails"] = "Edit Details",


            ["Admin.SocialMediaSharing.ShareMedia"] = "Media View",
            ["Admin.SocialMediaSharing.ShareMediaOption"] = "Share Option",
            ["Admin.ShareMediaOption.ShareOption.Fields.CustomMessage"] = "Custom Message",
            ["Admin.ShareMediaOption.ShareOption.Fields.zone"] = "Zone",

        });


        searchModel.SetGridPageSize();

        return searchModel;
    }
}
