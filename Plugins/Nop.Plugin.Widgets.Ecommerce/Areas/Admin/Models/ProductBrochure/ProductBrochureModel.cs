using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure;
public record ProductBrochureModel : BaseNopEntityModel
{
    #region Ctor
    public ProductBrochureModel()
    {
        ProductBrochureSearchModel = new ProductBrochureSearchModel();
    }

    #endregion

    #region Properties

    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ProductId")]
    public int ProductId { get; set; }

    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ButtonText")]

    public string ButtonText { get; set; }

    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ProductDownloadId")]

    [UIHint("Download")]
    public int ProductDownloadId { get; set; }

    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.IsActive")]
    public bool IsActive { get; set; }

    [NopResourceDisplayName("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.DisplayOrder")]
    public int DisplayOrder { get; set; }

    public ProductBrochureSearchModel ProductBrochureSearchModel { get; set; }

    #endregion
}
