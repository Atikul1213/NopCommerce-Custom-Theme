using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure;
public partial record ProductBrochureSearchModel : BaseSearchModel
{

    #region Properties
    public int ProductId { get; set; }

    #endregion
}
