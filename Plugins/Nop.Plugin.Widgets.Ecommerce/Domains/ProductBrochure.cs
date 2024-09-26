using Nop.Core;

namespace Nop.Plugin.Widgets.Ecommerce.Domains;
public class ProductBrochure : BaseEntity
{
    public int ProductId { get; set; }
    public string ButtonText { get; set; }
    public int ProductDownloadId { get; set; }
    public bool IsActive { get; set; }
    public int DisplayOrder { get; set; }
}
