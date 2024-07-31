using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.MediaFolder;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
public interface IShareMediaModelFactory
{
    Task<ShareMediaModel> PrepareShareMediaModelAsync(ShareMediaModel model, ShareMedia entity);
    Task<ShareMediaListModel> PrepareShareMediaListModelAsync(ShareMediaSearchModel searchModel);

    Task<ShareMedia> PrepareShareMediaAsync(ShareMediaModel media);

    Task<ShareMediaSearchModel> PrepareShareMediaSearchModelAsync(ShareMediaSearchModel searchModel);


}
