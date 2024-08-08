using Nop.Core;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Services;
public interface IShareMediaService
{
    Task InsertShareMediaAsync(ShareMedia media);

    Task UpdateShareMediaAsync(ShareMedia media);

    Task DeleteShareMediaAsync(ShareMedia media);

    Task<ShareMedia> GetShareMediaByIdAsync(int  shareId);

    Task<IList<ShareMedia>> GetAllShareMediaAsync();

    Task<IPagedList<ShareMedia>> SearchGetAllShareMediaAsync(int pageIndex = 0, int pageSize = int.MaxValue);
 
}
