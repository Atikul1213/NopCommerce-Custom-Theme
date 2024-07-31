using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public virtual async Task<ShareOption> GetShareOptionByIdAsync(int optionId)
    {
        
        return await _repository.GetByIdAsync(optionId);
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

    public virtual async Task<IPagedList<ShareOption>> SearchGetAllShareOptionAsync(int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var query = from m in _repository.Table
                    select m;
        return await query.ToPagedListAsync(pageIndex, pageSize);
    }

    public virtual async Task UpdateShareOptionAsync(ShareOption shareOption)
    {
        await _repository.UpdateAsync(shareOption);
    }
}
