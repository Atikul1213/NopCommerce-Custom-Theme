using Nop.Data;
using Nop.Plugin.Shipping.EuroQuip.Domain;

namespace Nop.Plugin.Shipping.EuroQuip.Services;
public partial class PickUpServices : IPickUpServices
{
    private readonly IRepository<PickUpDetails> _pickupDetailRepository;
    public PickUpServices(IRepository<PickUpDetails> pickupDetailRepository)
    {
        _pickupDetailRepository = pickupDetailRepository;
    }

    public virtual async Task<int> CreateClickAndCollectUserDetail(string firstName, string lastName, string email, string company, string cellphone, string collectionTime, string message)
    {

        var pickupDetailsRow = new PickUpDetails
        {
            FirstName = firstName,
            LastName = lastName,
            Company = company,
            CellPhone = cellphone,
            CollectionTime = DateTime.Parse(collectionTime),
            MessageBox = message,
            Email = email
        };

        await _pickupDetailRepository.InsertAsync(pickupDetailsRow);
        var rowId = _pickupDetailRepository.Table.ToList().Max(x => x.Id);
        return rowId;
    }

    public virtual async Task<PickUpDetails> GetPickupDetailById(int pickUpDetailId)
    {

        var row = await _pickupDetailRepository.GetByIdAsync(pickUpDetailId);
        return row;
    }

}
