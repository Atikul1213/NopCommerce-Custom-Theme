using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.MediaFolder;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
public interface IShareMediaModelFactory
{
    Task<ShareMediaModel> PrepareShareMediaModelAsync(ShareMedia media);
    Task<ShareMedia> PrepareShareMediaAsync(ShareMediaModel media);

    Task<ShareMediaListModel> PrepareShareMediaListModelAsync(ShareMediaSearchModel searchModel);
    Task<ShareMediaSearchModel> PrepareShareMediaSearchModelAsync(ShareMediaSearchModel searchModel);

    

}
