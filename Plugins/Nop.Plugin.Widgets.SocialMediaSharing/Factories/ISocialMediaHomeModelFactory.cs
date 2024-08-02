using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Plugin.Widgets.SocialMediaSharing.Models;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Factories;
public interface ISocialMediaHomeModelFactory
{
    Task<SocialMediaHomeModel> PrepareSocialMediaHomeModelAsync(ShareMedia entity);
    Task<IList<SocialMediaHomeModel>>PrepareSocialMediaListModelAsync(IList<ShareMedia> entity, string widgetZone); 

}
