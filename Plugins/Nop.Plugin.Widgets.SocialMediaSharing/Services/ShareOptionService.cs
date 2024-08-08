using Nop.Core;
using Nop.Data;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Services;
public class ShareOptionService : IShareOptionService
{

    private readonly IRepository<ShareOption> _repository;
    public ShareOptionService(IRepository<ShareOption> repository)
    {
        _repository = repository;   
    }
    public virtual async Task DeleteShareOptionAsync(ShareOption shareOption)
    {
       
        await _repository.DeleteAsync(shareOption);
    }

    public async Task<IList<ShareOption>> GetAllShareOptionAsync(int mediaId)
    {
        var option = await (from s in _repository.Table
                     where s.ShareMediaId == mediaId
                     select s).ToListAsync();
        
        return option;
                    
    }

    public virtual async Task<ShareOption> GetShareOptionByIdAsync(int mediaId)
    {
        
        return await _repository.GetByIdAsync(mediaId);
    }

    public virtual async Task<ShareOption> GetShareOptionByIdZoneAsync(int mediaId, string zone)
    {
        return await _repository.Table.Where(x => x.ShareMediaId == mediaId && x.Zone.Contains(zone)).FirstOrDefaultAsync();
    }

    public virtual async Task<IList<ShareOption>> GetShareOptionListAsync()
    {
        var query = from m in _repository.Table
                    select m; 
        return await query.ToListAsync();
    }

    public virtual async Task InsertShareOptionAsync(ShareOption shareOption)
    {
        await _repository.InsertAsync(shareOption);
    }

    public virtual async Task<IPagedList<ShareOption>> SearchGetAllShareOptionAsync(int shareId, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var query = from m in _repository.Table
                    where m.ShareMediaId==shareId
                    select m;
        return await query.ToPagedListAsync(pageIndex, pageSize);
    }

    public virtual async Task UpdateShareOptionAsync(ShareOption shareOption)
    {
        await _repository.UpdateAsync(shareOption);
    }
}
