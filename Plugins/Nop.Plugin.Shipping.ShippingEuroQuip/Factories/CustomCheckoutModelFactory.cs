using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Tax;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Shipping;
using Nop.Services.Shipping.Pickup;
using Nop.Services.Stores;
using Nop.Services.Tax;
using Nop.Web.Factories;
using Nop.Web.Models.Checkout;


namespace Nop.Plugin.Shipping.EuroQuip.Factories;
public class CustomCheckoutModelFactory : CheckoutModelFactory
{

    #region Fields

    private readonly AddressSettings _addressSettings;
    private readonly CaptchaSettings _captchaSettings;
    private readonly CommonSettings _commonSettings;
    private readonly IAddressModelFactory _addressModelFactory;
    private readonly IAddressService _addressService;
    private readonly ICountryService _countryService;
    private readonly ICurrencyService _currencyService;
    private readonly ICustomerService _customerService;
    private readonly IGenericAttributeService _genericAttributeService;
    private readonly ILocalizationService _localizationService;
    private readonly IOrderProcessingService _orderProcessingService;
    private readonly IOrderTotalCalculationService _orderTotalCalculationService;
    private readonly IPaymentPluginManager _paymentPluginManager;
    private readonly IPaymentService _paymentService;
    private readonly IPickupPluginManager _pickupPluginManager;
    private readonly IPriceFormatter _priceFormatter;
    private readonly IRewardPointService _rewardPointService;
    private readonly IShippingPluginManager _shippingPluginManager;
    private readonly IShippingService _shippingService;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IStateProvinceService _stateProvinceService;
    private readonly IStoreContext _storeContext;
    private readonly IStoreMappingService _storeMappingService;
    private readonly ITaxService _taxService;
    private readonly IWorkContext _workContext;
    private readonly OrderSettings _orderSettings;
    private readonly PaymentSettings _paymentSettings;
    private readonly RewardPointsSettings _rewardPointsSettings;
    private readonly ShippingSettings _shippingSettings;
    private readonly TaxSettings _taxSettings;

    #endregion

    #region Ctor

    public CustomCheckoutModelFactory(AddressSettings addressSettings,
        CaptchaSettings captchaSettings,
        CommonSettings commonSettings,
        IAddressModelFactory addressModelFactory,
        IAddressService addressService,
        ICountryService countryService,
        ICurrencyService currencyService,
        ICustomerService customerService,
        IGenericAttributeService genericAttributeService,
        ILocalizationService localizationService,
        IOrderProcessingService orderProcessingService,
        IOrderTotalCalculationService orderTotalCalculationService,
        IPaymentPluginManager paymentPluginManager,
        IPaymentService paymentService,
        IPickupPluginManager pickupPluginManager,
        IPriceFormatter priceFormatter,
        IRewardPointService rewardPointService,
        IShippingPluginManager shippingPluginManager,
        IShippingService shippingService,
        IShoppingCartService shoppingCartService,
        IStateProvinceService stateProvinceService,
        IStoreContext storeContext,
        IStoreMappingService storeMappingService,
        ITaxService taxService,
        IWorkContext workContext,
        OrderSettings orderSettings,
        PaymentSettings paymentSettings,
        RewardPointsSettings rewardPointsSettings,
        ShippingSettings shippingSettings,
        TaxSettings taxSettings) : base(

             addressSettings,
         captchaSettings,
         commonSettings,
         addressModelFactory,
         addressService,
         countryService,
         currencyService,
         customerService,
         genericAttributeService,
         localizationService,
         orderProcessingService,
         orderTotalCalculationService,
         paymentPluginManager,
         paymentService,
         pickupPluginManager,
         priceFormatter,
         rewardPointService,
         shippingPluginManager,
         shippingService,
         shoppingCartService,
         stateProvinceService,
         storeContext,
         storeMappingService,
         taxService,
         workContext,
         orderSettings,
         paymentSettings,
         rewardPointsSettings,
         shippingSettings,
         taxSettings

            )
    {
        _addressSettings = addressSettings;
        _captchaSettings = captchaSettings;
        _commonSettings = commonSettings;
        _addressModelFactory = addressModelFactory;
        _addressService = addressService;
        _countryService = countryService;
        _currencyService = currencyService;
        _customerService = customerService;
        _genericAttributeService = genericAttributeService;
        _localizationService = localizationService;
        _orderProcessingService = orderProcessingService;
        _orderTotalCalculationService = orderTotalCalculationService;
        _paymentPluginManager = paymentPluginManager;
        _paymentService = paymentService;
        _pickupPluginManager = pickupPluginManager;
        _priceFormatter = priceFormatter;
        _rewardPointService = rewardPointService;
        _shippingPluginManager = shippingPluginManager;
        _shippingService = shippingService;
        _shoppingCartService = shoppingCartService;
        _stateProvinceService = stateProvinceService;
        _storeContext = storeContext;
        _storeMappingService = storeMappingService;
        _taxService = taxService;
        _workContext = workContext;
        _orderSettings = orderSettings;
        _paymentSettings = paymentSettings;
        _rewardPointsSettings = rewardPointsSettings;
        _shippingSettings = shippingSettings;
        _taxSettings = taxSettings;
    }

    #endregion




    public override async Task<CheckoutShippingMethodModel> PrepareShippingMethodModelAsync(IList<ShoppingCartItem> cart, Address shippingAddress)
    {
        var model = new CheckoutShippingMethodModel
        {
            DisplayPickupInStore = _orderSettings.DisplayPickupInStoreOnShippingMethodPage
        };

        if (_orderSettings.DisplayPickupInStoreOnShippingMethodPage)
            model.PickupPointsModel = await PrepareCheckoutPickupPointsModelAsync(cart);

        model.PickupPointsModel = await PrepareCheckoutPickupPointsModelAsync(cart);

        var getShippingOptionResponse = await _shippingService.GetShippingOptionsAsync(cart, shippingAddress, await _workContext.GetCurrentCustomerAsync(), storeId: (await _storeContext.GetCurrentStoreAsync()).Id);
        if (getShippingOptionResponse.Success)
        {
            //performance optimization. cache returned shipping options.
            //we'll use them later (after a customer has selected an option).
            await _genericAttributeService.SaveAttributeAsync(await _workContext.GetCurrentCustomerAsync(),
                                                   NopCustomerDefaults.OfferedShippingOptionsAttribute,
                                                   getShippingOptionResponse.ShippingOptions,
                                                   (await _storeContext.GetCurrentStoreAsync()).Id);

            foreach (var shippingOption in getShippingOptionResponse.ShippingOptions)
            {
                var soModel = new CheckoutShippingMethodModel.ShippingMethodModel
                {
                    Name = shippingOption.Name,
                    Description = shippingOption.Description,
                    ShippingRateComputationMethodSystemName = shippingOption.ShippingRateComputationMethodSystemName,
                    ShippingOption = shippingOption,
                };

                //adjust rate
                var (shippingTotal, _) = await _orderTotalCalculationService.AdjustShippingRateAsync(shippingOption.Rate, cart, shippingOption.IsPickupInStore);

                var (rateBase, _) = await _taxService.GetShippingPriceAsync(shippingTotal, await _workContext.GetCurrentCustomerAsync());
                var rate = await _currencyService.ConvertFromPrimaryStoreCurrencyAsync(rateBase, await _workContext.GetWorkingCurrencyAsync());
                soModel.Fee = await _priceFormatter.FormatShippingPriceAsync(rate, true);

                model.ShippingMethods.Add(soModel);
            }

            //check if pickkup location previously selected
            var pickUpPoint = await _genericAttributeService.GetAttributeAsync<PickupPoint>(await _workContext.GetCurrentCustomerAsync(),
                    NopCustomerDefaults.SelectedPickupPointAttribute, (await _storeContext.GetCurrentStoreAsync()).Id);
            if (pickUpPoint != null)
            {
                model.PickupPointsModel.PickupInStore = true;
                //model.PickupPointsModel.SelectedPickupPoint = Convert.ToInt32(pickUpPoint.Id);

            }


            //find a selected (previously) shipping method
            var selectedShippingOption = await _genericAttributeService.GetAttributeAsync<ShippingOption>(await _workContext.GetCurrentCustomerAsync(),
                    NopCustomerDefaults.SelectedShippingOptionAttribute, (await _storeContext.GetCurrentStoreAsync()).Id);
            if (selectedShippingOption != null)
            {
                var shippingOptionToSelect = model.ShippingMethods.ToList()
                    .Find(so =>
                       !string.IsNullOrEmpty(so.Name) &&
                       so.Name.Equals(selectedShippingOption.Name, StringComparison.InvariantCultureIgnoreCase) &&
                       !string.IsNullOrEmpty(so.ShippingRateComputationMethodSystemName) &&
                       so.ShippingRateComputationMethodSystemName.Equals(selectedShippingOption.ShippingRateComputationMethodSystemName, StringComparison.InvariantCultureIgnoreCase));
                if (shippingOptionToSelect != null)
                {
                    shippingOptionToSelect.Selected = true;
                }
            }
            //if no option has been selected, let's do it for the first one
            if (model.ShippingMethods.FirstOrDefault(so => so.Selected) == null)
            {
                var shippingOptionToSelect = model.ShippingMethods.FirstOrDefault();
                if (shippingOptionToSelect != null)
                {
                    shippingOptionToSelect.Selected = true;
                }
            }

            //notify about shipping from multiple locations
            if (_shippingSettings.NotifyCustomerAboutShippingFromMultipleLocations)
            {
                model.NotifyCustomerAboutShippingFromMultipleLocations = getShippingOptionResponse.ShippingFromMultipleLocations;
            }
        }
        else
        {
            foreach (var error in getShippingOptionResponse.Errors)
                model.Warnings.Add(error);
        }

        return model;
    }




}
