using Nop.Plugin.Widgets.Ecommerce.Domain;
using Nop.Services.Caching;

namespace Nop.Plugin.Widgets.Ecommerce.Services.Caching;
public class CompanyCacheEventConsumer : CacheEventConsumer<Company>
{
    protected override async Task ClearCacheAsync(Company entity, EntityEventType entityEventType)
    {
        await RemoveByPrefixAsync(CompanyCacheDefaults.PREFIX);
        await base.ClearCacheAsync(entity, entityEventType);
    }

}
