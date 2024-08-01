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
    Task<ShareOptionListModel> PrepareShareOptionListModelAsync(ShareOptionSearchModel searchModel, ShareMedia entity);
    Task<ShareOptionModel> PrepareShareOptionModelAsync(ShareOptionModel model, ShareOption entity);

   Task<ShareOption> PrepareShareOptionAsync(ShareOptionModel model);







   // Task<ShareOptionSearchModel> PrepareShareOptionSearchModelAsync(ShareOptionSearchModel searchModel);
}
