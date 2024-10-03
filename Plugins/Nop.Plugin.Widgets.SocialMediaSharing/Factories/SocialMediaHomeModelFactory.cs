using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Plugin.Widgets.SocialMediaSharing.Models;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;
using Nop.Services.Media;
using Nop.Web.Models.Media;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Factories;
public class SocialMediaHomeModelFactory : ISocialMediaHomeModelFactory
{
    private readonly IShareMediaService _shareMediaService;
    private readonly IShareOptionService _shareOptionService;
    private readonly IPictureService _pictureService;
     

    public SocialMediaHomeModelFactory ( IShareMediaService shareMediaService, IShareOptionService shareOptionService , IPictureService pictureService)
    {
        
        _shareMediaService = shareMediaService;
        _shareOptionService = shareOptionService;
        _pictureService = pictureService;

    }

    public async Task<SocialMediaHomeModel> PrepareSocialMediaHomeModelAsync(ShareMedia entity)
    {
        var picture = await _pictureService.GetPictureByIdAsync(entity.IconId);

        var pictureModel = new PictureModel()
        {
            Id = entity.Id,
            AlternateText = "Picture of " + entity.Name,
            Title = "Picture of "+ entity.Name,
            ThumbImageUrl = (await _pictureService.GetPictureUrlAsync(picture,200)).Url,
            FullSizeImageUrl = (await _pictureService.GetPictureUrlAsync(picture)).Url 
        };

        var model = new SocialMediaHomeModel();
        model.Url = entity.Url;
        model.Name = entity.Name;
        model.Icon = pictureModel;

        return model;
    }



    public async Task<IList<SocialMediaHomeModel>> PrepareSocialMediaListModelAsync(IList<ShareMedia> entity, string widgetZone)
    {


        var mediaList = new List<SocialMediaHomeModel>();

        foreach (var media in entity)
        {

            var option = await _shareOptionService.GetAllShareOptionAsync(media.Id);
            
            if(option.Count()>0)
            {
                 option = option.Where(x => x.Zone.Contains(widgetZone)).ToList();
                 if(option.Any())
                  {
                        var model = await PrepareSocialMediaHomeModelAsync(media);

                        var obj = await _shareOptionService.GetShareOptionByIdZoneAsync(media.Id, widgetZone);

                        if (obj?.CustomMessage == null)
                            model.CustomMessage = " ";

                        else
                            model.CustomMessage = obj.CustomMessage;

                        model.Zone = widgetZone;
 
                        mediaList.Add(model);
                 }

            }

        }

        return mediaList;

    }




}
