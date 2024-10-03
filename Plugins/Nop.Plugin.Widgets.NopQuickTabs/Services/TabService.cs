using Nop.Core;
using Nop.Data;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;

namespace Nop.Plugin.Widgets.NopQuickTabs.Services;
public class TabService : ITabService
{
    private readonly IRepository<Tab> _repository;
    public TabService(IRepository<Tab> repository)
    {
        _repository = repository;
    }

    public virtual async Task DeleteTabAsync(Tab tab)
    {
        await _repository.DeleteAsync(tab);
    }

    public async Task<IPagedList<Tab>> GetAllTabAsync(int productId, int pageIndex = 0, int pageSize = int.MaxValue)
    {

        var query = from t in _repository.Table
                    where t.ProductId == productId
                    orderby t.DisplayOrder
                    select t;
        return await query.ToPagedListAsync(pageIndex, pageSize);

    }

    public async Task<IList<Tab>> GetProductTabList(int productId)
    {
        var query = await (from t in _repository.Table
                           where t.ProductId == productId && t.IsActive == true
                           orderby t.DisplayOrder
                           select t).ToListAsync();

        return query;
    }

    public virtual async Task<Tab> GetTabByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public virtual async Task InsertTabAsync(Tab tab)
    {
        await _repository.InsertAsync(tab);
    }

    public virtual async Task UpdateTabAsync(Tab tab)
    {
        await _repository.UpdateAsync(tab);
    }
}
