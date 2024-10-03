using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
public interface IShareOptionModelFactory
{
    Task<ShareOption> PrepareShareOptionAsync(ShareOptionModel model);
    Task<ShareOptionModel> PrepareShareOptionModelAsync(ShareOptionModel model, ShareOption entity);
    Task<ShareOptionListModel> PrepareShareOptionListModelAsync(ShareOptionSearchModel searchModel, ShareMedia entity);
}
