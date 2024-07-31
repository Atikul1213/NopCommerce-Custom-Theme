using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.MediaFolder;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
public interface IShareOptionModelFactory
{
    Task<ShareOption> PrepareShareOptionAsync(ShareOptionModel model);

    Task<ShareOptionModel> PrepareShareOptionModelAsync(ShareOption entity);

    Task<ShareOptionListModel> PrepareShareOptionListModelAsync(ShareOptionSearchModel searchModel);
    Task<ShareOptionSearchModel> PrepareShareOptionSearchModelAsync(ShareOptionSearchModel searchModel);
}
