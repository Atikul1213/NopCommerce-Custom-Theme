﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model;
public record CompanySearchModel : BaseSearchModel
{
    public CompanySearchModel()
    {
        AvailableCompanyOptions = new List<SelectListItem>();
    }
    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchName")]
    public string SearchName { get; set; }
    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchIsActive")]
    public bool SearchIsActive { get; set; }
    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchCompanyType")]
    public int SearchCompanyType { get; set; }

    public IList<SelectListItem> AvailableCompanyOptions { get; set; }


}
