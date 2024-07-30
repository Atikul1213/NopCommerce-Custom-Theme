using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;

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
             throw new NotImplementedException();
   
            var entity = new ShareMedia();

            entity = model.ToEntity(entity);
            
            
            return entity;
        
    }



    public async Task<IList<ShareMediaModel>> PrepareShareMediaListModelAsync()
    {

        var shareMedialList = await _shareMediaService.GetAllShareMediaAsync();

        var modelList = new List<ShareMediaModel>();
        
        foreach(var obj in shareMedialList)
        {
            var model = new ShareMediaModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Url = obj.Url,
                DisplayOrder = obj.DisplayOrder,
                IsActive = obj.IsActive,
                IconId = obj.IconId
            };

            var picture = await _pictureService.GetPictureByIdAsync(obj.IconId);
            (model.IconThumbnailUrl, _) = await _pictureService.GetPictureUrlAsync(picture, 75);
            modelList.Add(model);
        }

        return modelList;

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
}
