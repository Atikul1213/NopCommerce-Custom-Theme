using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Orders;
using Nop.Services.Shipping;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Shipping.EuroQuip.Components;
public class ShippingMethodCartViewComponent : NopViewComponent
{
    private readonly IWorkContext _workContext;
    private readonly IAddressService _addressService;
    private readonly IStoreContext _storeContext;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly ICustomerService _customerService;
    private readonly IShippingService _shippingService;
    private readonly ICheckoutModelFactory _checkoutModelFactory;
    public ShippingMethodCartViewComponent(IWorkContext workContext,
        IAddressService addressService,
        IStoreContext storeContext,
        IShoppingCartService shoppingCartService,
        ICustomerService customerService,
        IShippingService shippingService,
        ICheckoutModelFactory checkoutModelFactory)
    {
        _workContext = workContext;
        _addressService = addressService;
        _storeContext = storeContext;
        _shoppingCartService = shoppingCartService;
        _customerService = customerService;
        _shippingService = shippingService;
        _checkoutModelFactory = checkoutModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {

        var cart = await _shoppingCartService.GetShoppingCartAsync(await _workContext.GetCurrentCustomerAsync(), ShoppingCartType.ShoppingCart, (await _storeContext.GetCurrentStoreAsync()).Id);
        var address = await _addressService.GetAddressByIdAsync(1);
        var shippingMethodModel = await _checkoutModelFactory.PrepareShippingMethodModelAsync(cart, address);

        return View(shippingMethodModel);

    }

}
