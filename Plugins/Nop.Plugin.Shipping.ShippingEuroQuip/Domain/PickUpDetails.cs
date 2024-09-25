using Nop.Core;

namespace Nop.Plugin.Shipping.EuroQuip.Domain;
public class PickUpDetails : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }

    public string CellPhone { get; set; }

    public DateTime CollectionTime { get; set; }

    public string MessageBox { get; set; }

    public string Email { get; set; }

}
