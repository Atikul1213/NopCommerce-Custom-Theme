using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model;
public record CompanyModel : BaseNopEntityModel, ILocalizedModel<CompanyLocalizedModel>
{

    public CompanyModel()
    {
        AvailableCompanyOptions = new List<SelectListItem>();
        Locales = new List<CompanyLocalizedModel>();
    }


    public string Name { get; set; }

    public string Description { get; set; }
    public int DisplayOrder { get; set; }
    [ValidateNever]
    public string PictureThumbnailUrl { get; set; }

    [UIHint("Picture")]
    public int PictureId { get; set; }
    public bool IsActive { get; set; }

    public string CompanyTypeStr { get; set; }

    public IList<SelectListItem> AvailableCompanyOptions { get; set; }

    public IList<CompanyLocalizedModel> Locales { get; set; }


}



public partial record CompanyLocalizedModel : ILocalizedLocaleModel
{
    public CompanyLocalizedModel()
    {

    }

    public int LanguageId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}