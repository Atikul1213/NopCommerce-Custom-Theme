using Nop.Plugin.Shipping.EuroQuip.Models;

namespace Nop.Plugin.Shipping.EuroQuip.Factories;
public partial interface IPickupDetailModelFactory
{
    Task<PickupDetailModel> PreparePickupDetailModelByIdAsync(int id);
}
