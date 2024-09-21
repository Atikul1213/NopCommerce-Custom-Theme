using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.CompanyModel;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.CompanyFactory;
public interface ICompanyModelFactory
{
    Task<CompanyListModel> PrepareCompanyListModelAsync(CompanySearchModel searchModel);
    Task<CompanySearchModel> PrepareCompanySearchModelAsync(CompanySearchModel searchModel);
    Task<CompanyModel> PrepareCompanyModelAsync(CompanyModel model, Company company, bool excludeProperties = false);
}
