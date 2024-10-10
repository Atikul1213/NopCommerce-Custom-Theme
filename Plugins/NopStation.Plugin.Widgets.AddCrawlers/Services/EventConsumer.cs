using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Events;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Events;

namespace NopStation.Plugin.Widgets.AddCrawlers.Services;
public class EventConsumer : IConsumer<EntityInsertedEvent<Customer>>
{
    #region Fields
    private readonly ISettingService _settingService;
    private readonly IStoreContext _storeContext;
    private readonly ICustomerService _customerService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion

    #region Ctors
    public EventConsumer(ISettingService settingService,
        IStoreContext storeContext,
        ICustomerService customerService,
        IHttpContextAccessor httpContextAccessor)
    {
        _settingService = settingService;
        _storeContext = storeContext;
        _customerService = customerService;
        _httpContextAccessor = httpContextAccessor;
    }

    #endregion


    #region Methods

    public async Task HandleEventAsync(EntityInsertedEvent<Customer> eventMessage)
    {
        var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
        var productApprovalSettings = await _settingService.LoadSettingAsync<AddCrawlerSettings>(storeScope);
        if (!productApprovalSettings.IsEnabled)
            return;
        var customer = eventMessage.Entity;
        //if (customer == null || customer.Id <= 0 || customer.)
    }

    #endregion

}
