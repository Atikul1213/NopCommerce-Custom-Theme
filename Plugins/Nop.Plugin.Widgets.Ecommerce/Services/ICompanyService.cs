using Nop.Core;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Services;
public interface ICompanyService
{
    Task InsertCompanyAsync(Company company);

    Task UpdateCompanyAsync(Company company);

    Task DeleteCompanyAsync(Company company);

    Task<Company> GetCompanyByIdAsync(int companyId);

    Task<IList<Company>> GetAllCompanyAsync();

    Task<IPagedList<Company>> SearchCompanysAsync(string name, int companyType, bool isActive, int pageIndex = 0, int pageSize = int.MaxValue);
}
