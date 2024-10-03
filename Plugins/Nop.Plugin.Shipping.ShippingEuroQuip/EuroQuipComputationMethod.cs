using Nop.Core;
using Nop.Core.Domain.Shipping;
using Nop.Plugin.Shipping.EuroQuip.Components;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Shipping;
using Nop.Services.Shipping.Tracking;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Shipping.EuroQuip
{
    public class EuroQuipComputationMethod : BasePlugin, IWidgetPlugin, IShippingRateComputationMethod
    {
        #region Fields


        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;
        private readonly IStoreContext _storeContext;
        private readonly IShippingService _shippingService;
        private readonly ISettingService _settingService;

        #endregion
        public bool HideInWidgetList => false;


        #region Ctor
        public EuroQuipComputationMethod(ILocalizationService localizationService,
            IWebHelper webHelper,
            IStoreContext storeContext,
            IShippingService shippingService,
            ISettingService settingService
            )
        {
            _localizationService = localizationService;
            _webHelper = webHelper;
            _storeContext = storeContext;
            _shippingService = shippingService;
            _settingService = settingService;
        }

        #endregion

        #region Utilities


        protected async Task<decimal> GetRateAsync(int shippingMethodId)
        {
            return await _settingService.GetSettingByKeyAsync<decimal>(string.Format(EuroQuipDefaults.FIXED_RATE_SETTINGS_KEY, shippingMethodId));
        }


        protected async Task<bool> GetIsPickUpAsync(int shippingMethodId)
        {
            return await _settingService.GetSettingByKeyAsync<bool>(string.Format(EuroQuipDefaults.IS_PICKUP_SETTINGS_KEY, shippingMethodId));
        }

        #endregion


        #region Method



        public Task<IList<string>> GetWidgetZonesAsync()
        {

            return Task.FromResult<IList<string>>(
                new List<string>
                {
                PublicWidgetZones.HomepageTop
                });
        }

        public Type GetWidgetViewComponent(string widgetZone)
        {

            return typeof(ShippingMethodCartViewComponent);
        }


        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/ShippingEuroQuip/Configure";
        }

        public override async Task InstallAsync()
        {
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Nop.Plugin.Shipping.EuroQuip.Models.FixedRateModel.Fields.ShippingMethodName"] = "Shipping method",
                ["Nop.Plugin.Shipping.EuroQuip.Models.FixedRateModel.Fields.Rate"] = "Rate",
                ["Nop.Plugin.Shipping.EuroQuip.Models.FixedRateModel.Fields.IsPickUp"] = "Pick up"
            });
            await base.InstallAsync();
        }


        public override async Task UninstallAsync()
        {

            await _localizationService.DeleteLocaleResourceAsync("Nop.Plugin.Shipping.EuroQuip.Models.FixedRateModel.Fields");
            await base.UninstallAsync();
        }


        public async Task<decimal?> GetFixedRateAsync(GetShippingOptionRequest getShippingOptionRequest)
        {
            ArgumentNullException.ThrowIfNull(getShippingOptionRequest);

            //if the "shipping calculation by weight" method is selected, the fixed rate isn't calculated

            var restrictByCountryId = getShippingOptionRequest.ShippingAddress?.CountryId;
            var rates = await (await _shippingService.GetAllShippingMethodsAsync(restrictByCountryId))
                .SelectAwait(async shippingMethod => await GetRateAsync(shippingMethod.Id)).Distinct().ToListAsync();

            //return default rate if all of them equal
            if (rates.Count == 1)
                return rates.FirstOrDefault();

            return null;
        }

        public async Task<IShipmentTracker> GetShipmentTrackerAsync()
        {
            return await Task.FromResult<IShipmentTracker>(null);
        }

        public async Task<GetShippingOptionResponse> GetShippingOptionsAsync(GetShippingOptionRequest getShippingOptionRequest)
        {
            ArgumentNullException.ThrowIfNull(getShippingOptionRequest);

            var response = new GetShippingOptionResponse();

            if (getShippingOptionRequest.Items == null || !getShippingOptionRequest.Items.Any())
            {
                response.AddError("No shipment items");
                return response;
            }

            var restrictByCountryId = getShippingOptionRequest.ShippingAddress?.CountryId;
            response.ShippingOptions = await (await _shippingService.GetAllShippingMethodsAsync(restrictByCountryId)).SelectAwait(async shippingMethod => new ShippingOption
            {
                Name = await _localizationService.GetLocalizedAsync(shippingMethod, x => x.Name),
                Description = await _localizationService.GetLocalizedAsync(shippingMethod, x => x.Description),
                Rate = await GetRateAsync(shippingMethod.Id),
                IsPickupInStore = await GetIsPickUpAsync(shippingMethod.Id)
            }).ToListAsync();


            return response;
        }


        #endregion
    }
}
