using Nop.Core;
using Nop.Data;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Services;
public class CompanyService : ICompanyService
{
    private readonly IRepository<Company> _companyRepository;

    public CompanyService(IRepository<Company> companyRepository)
    {
        _companyRepository = companyRepository;
    }


    public virtual async Task InsertCompanyAsync(Company company)
    {
        await _companyRepository.InsertAsync(company);
    }

    public virtual async Task UpdateCompanyAsync(Company company)
    {
        await _companyRepository.UpdateAsync(company);
    }

    public virtual async Task DeleteCompanyAsync(Company company)
    {
        await _companyRepository.DeleteAsync(company);
    }
    public virtual async Task<Company> GetCompanyByIdAsync(int companyId)
    {
        return await _companyRepository.GetByIdAsync(companyId);
    }

    public virtual async Task<IList<Company>> GetAllCompanyAsync()
    {
        var query = from c in _companyRepository.Table
                    select c;
        query = query.OrderBy(x => x.DisplayOrder);

        return await query.ToListAsync();
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
