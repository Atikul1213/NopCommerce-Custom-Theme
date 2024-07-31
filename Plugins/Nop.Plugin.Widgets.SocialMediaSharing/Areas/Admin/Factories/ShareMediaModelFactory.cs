using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.MediaFolder;
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
    public ShareMediaModelFactory(ILocalizationService localizationService, IShareMediaService shareMediaService, IPictureService pictureService)
    {
        _localizationService = localizationService;
        _shareMediaService = shareMediaService;
        _pictureService = pictureService;
    }




    public async Task<ShareMedia> PrepareShareMediaAsync(ShareMediaModel model)
    {


        if (model == null)
             throw  new NotImplementedException();
   
            var entity =  new ShareMedia();

            entity =  model.ToEntity(entity);
           return  entity;
    }



    public async Task<ShareMediaListModel> PrepareShareMediaListModelAsync(ShareMediaSearchModel searchModel)
    {


        var shareMedialList = await _shareMediaService.SearchGetAllShareMediaAsync(pageIndex: searchModel.Page-1, pageSize: searchModel.PageSize);


        var model = await new ShareMediaListModel().PrepareToGridAsync(searchModel, shareMedialList, () =>
        {
            return shareMedialList.SelectAwait(async s =>
            {
                return await PrepareShareMediaModelAsync(s);
            });

        });

        return model;

    }

    public async Task<ShareMediaModel> PrepareShareMediaModelAsync(ShareMedia entiy)
    {
        if(entiy==null)
           throw new NotImplementedException();

        var model =  new ShareMediaModel();
        model = entiy.ToModel(model);

        var picture = await _pictureService.GetPictureByIdAsync(entiy.IconId);
        (model.IconThumbnailUrl, _) = await _pictureService.GetPictureUrlAsync(picture, 75);
        return model;

    }

    public async Task<ShareMediaSearchModel> PrepareShareMediaSearchModelAsync(ShareMediaSearchModel searchModel)
    {

        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            ["Admin.Widget.SocialMediaSharing.Model.Name"] = "Media Name",
            ["Admin.Widget.SocialMediaSharing.Model.Url"] = "Url",
            ["Admin.Widget.SocialMediaSharing.Model.DisplayOrder"] = "DisplayOrder",
            ["Admin.Widget.SocialMediaSharing.Model.IsActive"] = "IsActive",
            ["Admin.Widget.SocialMediaSharing.Model.IconId"] = "IconId",
            ["Admin.Widget.ShareMedia.AddNew"] = "AddNew",
            ["Admin.Widget.ShareMedia.BackToList"] = "BackToList",



            ["Admin.Widget.ShareMedia"] = "ShareMedia",
            ["Admin.Widget.SocialMediaSharing.Model.Id"] = "Edit",
            ["Admin.Widget.SocialMediaSharing.Model.Icon"] = "Icon",
            ["Admin.Widget.ShareMedia.EditDetails"] = "Edit Details",




        });
        searchModel.SetGridPageSize();

        return searchModel;
    }
}
