using Nop.Plugin.Shipping.EuroQuip.Domain;

namespace Nop.Plugin.Shipping.EuroQuip.Services;
public partial interface IPickUpServices
{
    Task<int> CreateClickAndCollectUserDetail(string firstName, string lastName, string email, string company, string cellphone, string collectionTime, string message);

    Task<PickUpDetails> GetPickupDetailById(int pickUpDetailId);
}
