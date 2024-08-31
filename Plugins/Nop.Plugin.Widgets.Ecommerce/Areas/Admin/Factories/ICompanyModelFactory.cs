using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories;
public interface ICompanyModelFactory
{
    Task<CompanyListModel> PrepareCompanyListModelAsync(CompanySearchModel searchModel);
    Task<CompanySearchModel> PrepareCompanySearchModelAsync(CompanySearchModel searchModel);
    Task<CompanyModel> PrepareCompanyModelAsync(CompanyModel model, Company employee, bool excludeProperties = false);
}
