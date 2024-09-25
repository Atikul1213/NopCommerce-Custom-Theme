using Nop.Plugin.Shipping.EuroQuip.Models;
using Nop.Plugin.Shipping.EuroQuip.Services;

namespace Nop.Plugin.Shipping.EuroQuip.Factories;
public partial class PickupDetailModelFactory : IPickupDetailModelFactory
{
    private readonly IPickUpServices _pickUpServices;

    public PickupDetailModelFactory(IPickUpServices pickUpServices)
    {
        _pickUpServices = pickUpServices;
    }

    public virtual async Task<PickupDetailModel> PreparePickupDetailModelByIdAsync(int id)
    {
        var pickupDetails = await _pickUpServices.GetPickupDetailById(id);

        PickupDetailModel pModel = new PickupDetailModel
        {
            FirstName = pickupDetails.FirstName,
            LastName = pickupDetails.LastName,
            Company = pickupDetails.Company,
            CellPhone = pickupDetails.CellPhone,
            CollectionTime = pickupDetails.CollectionTime,
            MessageBox = pickupDetails.MessageBox,
            Email = pickupDetails.Email
        };

        return pModel;
    }
}
