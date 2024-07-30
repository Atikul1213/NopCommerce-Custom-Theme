using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
public interface IShareMediaModelFactory
{
    Task<ShareMediaModel> PrepareShareMediaModelAsync(ShareMedia media);
    Task<ShareMedia> PrepareShareMediaAsync(ShareMediaModel media);

    Task<IList<ShareMediaModel>> PrepareShareMediaListModelAsync();
}
