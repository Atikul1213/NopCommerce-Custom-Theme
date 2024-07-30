using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Services;
public interface IShareMediaService
{
    Task InsertShareMediaAsync(ShareMedia media);

    Task UpdateShareMediaAsync(ShareMedia media);

    Task DeleteShareMediaAsync(ShareMedia media);

    Task<ShareMedia> GetShareMediaByIdAsync(int  shareId);

    Task<IList<ShareMedia>> GetAllShareMediaAsync();
    
}
