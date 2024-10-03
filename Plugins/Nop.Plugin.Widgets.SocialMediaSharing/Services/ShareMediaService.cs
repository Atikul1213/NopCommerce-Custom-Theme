using Nop.Core;
using Nop.Data;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Services;
public class ShareMediaService : IShareMediaService
{

    private readonly IRepository<ShareMedia> _repository;
    public ShareMediaService( IRepository<ShareMedia> repository)
    {
        _repository = repository;
    }

    public virtual async Task DeleteShareMediaAsync(ShareMedia media)
    {
        
        await _repository.DeleteAsync(media);
    }

    public virtual async Task<IList<ShareMedia>> GetAllShareMediaAsync()
    {
        var query = from m in _repository.Table
                    select m;
        query = query.OrderBy(x => x.DisplayOrder);

        return await query.ToListAsync();
    }

  
    public virtual async Task<IPagedList<ShareMedia>> SearchGetAllShareMediaAsync(int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var query = from m in _repository.Table
                    select m;
        query = query.OrderBy(x => x.DisplayOrder);

        return await query.ToPagedListAsync(pageIndex, pageSize);
    }


    public virtual async Task<ShareMedia> GetShareMediaByIdAsync(int shareId)
    {

        return await _repository.GetByIdAsync(shareId);
    }

    public virtual async Task InsertShareMediaAsync(ShareMedia media)
    {
        await _repository.InsertAsync(media);
    }

    public virtual async Task UpdateShareMediaAsync(ShareMedia media)
    {
        
        await _repository.UpdateAsync(media);
    }
}
