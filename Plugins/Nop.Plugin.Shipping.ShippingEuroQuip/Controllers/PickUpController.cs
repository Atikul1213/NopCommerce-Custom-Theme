using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Plugin.Shipping.EuroQuip.Services;
using Nop.Services.Common;
using Nop.Web.Controllers;

namespace Nop.Plugin.Shipping.EuroQuip.Controllers;
public partial class PickUpController : BasePublicController
{

    private readonly IPickUpServices _pickUpServices;
    private readonly IWorkContext _workContext;
    private readonly IGenericAttributeService _genericAttributeService;
    private readonly IStoreContext _storeContext;

    public PickUpController(IPickUpServices pickUpServices,
         IWorkContext workContext,
         IGenericAttributeService genericAttributeService,
         IStoreContext storeContext)
    {
        _pickUpServices = pickUpServices;
        _workContext = workContext;
        _genericAttributeService = genericAttributeService;
        _storeContext = storeContext;
    }


    public virtual async Task<IActionResult> CreateClickAndCollectUserDetail(string firstName, string lastName, string email, string company, string cellphone, string collectionTime, string message)
    {
        var pickUpDetailId = await _pickUpServices.CreateClickAndCollectUserDetail(firstName, lastName, email, company, cellphone, collectionTime, message);
        if (pickUpDetailId > 0)
        {
            await _genericAttributeService.SaveAttributeAsync<int>(await _workContext.GetCurrentCustomerAsync(), NopCustomerDefaults.SelectedPickupPointAttribute, pickUpDetailId, (await _storeContext.GetCurrentStoreAsync()).Id);
            return Json("Success");
        }
        else
        {
            return Json("Failed");

        }
    }
}
