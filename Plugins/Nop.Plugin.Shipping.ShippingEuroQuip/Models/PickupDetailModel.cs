using Nop.Web.Framework.Models;

namespace Nop.Plugin.Shipping.EuroQuip.Models;
public record PickupDetailModel : BaseNopEntityModel
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }

    public string CellPhone { get; set; }

    public DateTime CollectionTime { get; set; }

    public string MessageBox { get; set; }

    public string Email { get; set; }
}
