using Nop.Core;
using Nop.Core.Caching;
using Nop.Data;
using Nop.Plugin.Widgets.Ecommerce.Domains;
using Nop.Plugin.Widgets.Ecommerce.Services.CompanyServices.Caching;

namespace Nop.Plugin.Widgets.Ecommerce.Services.CompanyServices;
public class CompanyService : ICompanyService
{
    private readonly IRepository<Company> _companyRepository;
    private readonly IStaticCacheManager _staticCacheManager;

    public CompanyService(IRepository<Company> companyRepository, IStaticCacheManager staticCacheManager)
    {
        _companyRepository = companyRepository;
        _staticCacheManager = staticCacheManager;
    }


    public virtual async Task InsertCompanyAsync(Company company)
    {
        await _companyRepository.InsertAsync(company);
    }

    public virtual async Task<IList<Company>> GetCompaniesByIdsAsync(int[] ids)
    {
        return await _companyRepository.GetByIdsAsync(ids, cache => default);
    }

    public virtual async Task UpdateCompanyAsync(Company company)
    {
        await _companyRepository.UpdateAsync(company);
    }

    public virtual async Task DeleteCompanyAsync(Company company)
    {
        await _companyRepository.DeleteAsync(company);
    }

    public virtual async Task DeleteCompanysAsync(IList<Company> companies)
    {
        await _companyRepository.DeleteAsync(companies);
    }
    public virtual async Task<Company> GetCompanyByIdAsync(int companyId)
    {
        return await _companyRepository.GetByIdAsync(companyId, cache => default);
    }

    public virtual async Task<IList<Company>> GetAllCompanyAsync()
    {
        var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(CompanyCacheDefaults.GetAllCompanyAsync);

        return await _staticCacheManager.GetAsync(cacheKey, async () =>
        {
            var companies = await _companyRepository.GetAllAsync(query => query.OrderBy(o => o.DisplayOrder), cache => default);
            return companies;
        });


    }



    public virtual async Task<IPagedList<Company>> SearchCompanysAsync(string name = null, int companyType = 0, bool isActive = true, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var query = from c in _companyRepository.Table
                    select c;

        if (!string.IsNullOrEmpty(name))
            query = query.Where(x => x.Name.Contains(name));


        if (companyType > 0)
            query = query.Where(x => x.CompanyType == companyType);


        query = query.OrderBy(c => c.DisplayOrder);

        return await query.ToPagedListAsync(pageIndex, pageSize);

    }

}
