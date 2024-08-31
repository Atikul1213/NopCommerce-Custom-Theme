using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model;
public record CompanySearchModel : BaseSearchModel
{
    public CompanySearchModel()
    {
        AvailableCompanyOptions = new List<SelectListItem>();
    }

    public string SearchName { get; set; }
    public bool SearchIsActive { get; set; }
    public int SearchCompanyType { get; set; }
    public IList<SelectListItem> AvailableCompanyOptions { get; set; }


}
