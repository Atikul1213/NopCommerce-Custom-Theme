using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
public class ShareOptionModelFactory : IShareOptionModelFactory
{

    private readonly IShareOptionService _shareOptionService;
    public ShareOptionModelFactory(IShareOptionService shareOptionService)
    {
        _shareOptionService = shareOptionService;
    }



    public async Task<ShareOptionListModel> PrepareShareOptionListModelAsync(ShareOptionSearchModel searchModel, ShareMedia media)
    {
        ArgumentNullException.ThrowIfNull(searchModel);
        ArgumentNullException.ThrowIfNull(media);

        var mediaOptionList = await _shareOptionService.SearchGetAllShareOptionAsync(media.Id, pageIndex:searchModel.Page-1, pageSize:searchModel.PageSize);

       
        var model = await new ShareOptionListModel().PrepareToGridAsync(searchModel, mediaOptionList, () =>
        {
            return mediaOptionList.SelectAwait(async obj=>
            {
                //var shareOptionModel = new ShareOptionModel()
                //{
                //    CustomMessage = obj.CustomMessage,
                //    ShareMediaId = obj.ShareMediaId,
                //    IncludedLink = obj.IncludedLink,
                //    zone = obj.zone
                //};
                return await PrepareShareOptionModelAsync(new ShareOptionModel(), obj);
            });
        });

        return model;

    }

    public async Task<ShareOptionModel> PrepareShareOptionModelAsync(ShareOptionModel model, ShareOption entity)
    {
        if (entity == null)
            throw new NotImplementedException();

        var obj = new ShareOptionModel()
        {
            Id = entity.Id,
            ShareMediaId = entity.Id,
            CustomMessage = entity.CustomMessage,
            IncludedLink = entity.IncludedLink,
            zone = entity.zone
        };
        return obj;
    }



    public async Task<ShareOption> PrepareShareOptionAsync(ShareOptionModel model)
    {
        if (model == null)
            throw new NotImplementedException();

        var entity = new ShareOption()
        {
            ShareMediaId = model.ShareMediaId,
            CustomMessage = model.CustomMessage,
            IncludedLink = model.IncludedLink,
            zone = model.zone
            
        };
        entity.Id = model.Id;

        return entity;

    }








    //public async Task<ShareOptionSearchModel> PrepareShareOptionSearchModelAsync(ShareOptionSearchModel searchModel)
    //{
    //    //throw new NotImplementedException();

    //    searchModel.SetGridPageSize();
    //    return searchModel;
    //}



}
