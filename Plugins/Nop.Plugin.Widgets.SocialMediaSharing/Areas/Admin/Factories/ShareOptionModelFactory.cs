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

    public async Task<ShareOptionModel> PrepareShareOptionModelAsync(ShareOption entity)
    {
        if(entity == null)
            throw new NotImplementedException();
        var model = new ShareOptionModel()
        {
            Id = entity.Id,
            ShareMediaId = entity.Id,
            CustomMessage = entity.CustomMessage,
            IncludedLink = entity.IncludedLink,
            zone = entity.zone
        };
        model.WidgetZoneList = WidgetZoneHelper.GetAllWidgetZone();
        return model;
    }

    public async Task<ShareOption> PrepareShareOptionAsync(ShareOptionModel model)
    {
        if(model == null) 
        throw new NotImplementedException();

        var entity = new ShareOption()
        {
           ShareMediaId = model.ShareMediaId,
           CustomMessage = model.CustomMessage,
           IncludedLink = model.IncludedLink,
           zone = model.zone
        };

        return  entity;

    }

    public async Task<ShareOptionListModel> PrepareShareOptionListModelAsync(ShareOptionSearchModel searchModel)
    {

        var shareOptionList = await _shareOptionService.SearchGetAllShareOptionAsync(pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

        var model = await new ShareOptionListModel().PrepareToGridAsync(searchModel, shareOptionList, () =>
        {
            return shareOptionList.SelectAwait(async s =>
            {
                return await PrepareShareOptionModelAsync(s);
            });

        });
        return model;
        
    }

    public async Task<ShareOptionSearchModel> PrepareShareOptionSearchModelAsync(ShareOptionSearchModel searchModel)
    {
        //throw new NotImplementedException();

        searchModel.SetGridPageSize();
        return searchModel;
    }
}
