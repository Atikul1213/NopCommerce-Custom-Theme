using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.Ecommerce.Models.ProductBrochure;
public record ProductBrochureInfoModel : BaseNopEntityModel
{
    public int ProductId { get; set; }
    public string ButtonText { get; set; }
    public int ProductDownloadId { get; set; }
    public Guid DownloadGuid { get; set; }
}
