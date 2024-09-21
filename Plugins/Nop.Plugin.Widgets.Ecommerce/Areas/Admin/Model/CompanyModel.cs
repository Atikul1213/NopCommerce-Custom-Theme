using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model;
public record CompanyModel : BaseNopEntityModel, ILocalizedModel<CompanyLocalizedModel>
{
    #region Ctor
    public CompanyModel()
    {
        AvailableCompanyOptions = new List<SelectListItem>();
        Locales = new List<CompanyLocalizedModel>();
    }

    #endregion

    #region Properties

    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Description")]
    [ValidateNever]
    public string Description { get; set; }
    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.DisplayOrder")]
    public int DisplayOrder { get; set; }
    [ValidateNever]
    public string PictureThumbnailUrl { get; set; }

    [UIHint("Picture")]
    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Picture")]
    public int PictureId { get; set; }
    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.IsActive")]
    public bool IsActive { get; set; }

    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.CompanyTypeStr")]
    public string CompanyTypeStr { get; set; }

    public IList<SelectListItem> AvailableCompanyOptions { get; set; }
    [ValidateNever]
    public IList<CompanyLocalizedModel> Locales { get; set; }

    #endregion

}


#region Localized

public partial record CompanyLocalizedModel : ILocalizedLocaleModel
{
    public CompanyLocalizedModel()
    {

    }

    public int LanguageId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

#endregion