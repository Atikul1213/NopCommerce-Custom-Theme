using Nop.Core;
using Nop.Core.Domain.Common;

namespace Nop.Plugin.Shipping.EuroQuip.Domain;
public partial class PickUpOrder : BaseEntity, ISoftDeletedEntity
{
    public int PickUpDetailId { get; set; }

    public string OrderNotes { get; set; }
    public bool Deleted { get; set; }
}
