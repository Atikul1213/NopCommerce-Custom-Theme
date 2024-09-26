using Nop.Core;
using Nop.Plugin.Widgets.Ecommerce.Domains;

namespace Nop.Plugin.Widgets.Ecommerce.Services.CompanyServices;
public interface ICompanyService
{
    Task InsertCompanyAsync(Company company);

    Task UpdateCompanyAsync(Company company);

    Task DeleteCompanyAsync(Company company);

    Task DeleteCompanysAsync(IList<Company> companies);

    Task<Company> GetCompanyByIdAsync(int companyId);
    Task<IList<Company>> GetCompaniesByIdsAsync(int[] ids);

    Task<IList<Company>> GetAllCompanyAsync();

    Task<IPagedList<Company>> SearchCompanysAsync(string name, int companyType, bool isActive, int pageIndex = 0, int pageSize = int.MaxValue);
}
