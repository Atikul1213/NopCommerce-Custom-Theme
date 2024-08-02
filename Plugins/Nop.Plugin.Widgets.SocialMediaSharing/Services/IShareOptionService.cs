using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Services;
public interface IShareOptionService
{




    Task InsertShareOptionAsync(ShareOption shareOption);
    Task UpdateShareOptionAsync(ShareOption shareOption);
    Task DeleteShareOptionAsync(ShareOption shareOption);
    

    Task<ShareOption> GetShareOptionByIdAsync(int mediaId);

    Task<IList<ShareOption>> GetShareOptionListAsync();

    Task<IPagedList<ShareOption>> SearchGetAllShareOptionAsync(int shareId, int pageIndex=0, int pageSize=int.MaxValue);


    Task<IList<ShareOption>> GetAllShareOptionAsync(int mediaId);
}
