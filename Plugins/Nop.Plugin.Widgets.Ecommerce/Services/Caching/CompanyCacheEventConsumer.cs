using Nop.Core.Events;
using Nop.Plugin.Widgets.Ecommerce.Domain;
using Nop.Services.Caching;

namespace Nop.Plugin.Widgets.Ecommerce.Services.Caching;
public class CompanyCacheEventConsumer : CacheEventConsumer<Company>
{
    public override async Task HandleEventAsync(EntityInsertedEvent<Company> eventMessage)
    {
        await RemoveByPrefixAsync(CompanyCacheDefaults.COMPANY_ADMIN_PREFIX);
        await RemoveByPrefixAsync(CompanyCacheDefaults.COMPANY_PUBLIC_PREFIX);
        await base.HandleEventAsync(eventMessage);
    }

    public override async Task HandleEventAsync(EntityUpdatedEvent<Company> eventMessage)
    {
        await RemoveByPrefixAsync(CompanyCacheDefaults.COMPANY_ADMIN_PREFIX);
        await RemoveByPrefixAsync(CompanyCacheDefaults.COMPANY_PUBLIC_PREFIX);
        await base.HandleEventAsync(eventMessage);
    }

    public override async Task HandleEventAsync(EntityDeletedEvent<Company> eventMessage)
    {
        await RemoveByPrefixAsync(CompanyCacheDefaults.COMPANY_ADMIN_PREFIX);
        await RemoveByPrefixAsync(CompanyCacheDefaults.COMPANY_PUBLIC_PREFIX);
        await base.HandleEventAsync(eventMessage);
    }
}
