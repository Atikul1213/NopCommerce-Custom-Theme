using Nop.Plugin.Widgets.Ecommerce.Domains;
using Nop.Services.Caching;

namespace Nop.Plugin.Widgets.Ecommerce.Services.CompanyServices.Caching;
public class CompanyCacheEventConsumer : CacheEventConsumer<Company>
{
    protected override async Task ClearCacheAsync(Company entity, EntityEventType entityEventType)
    {
        await RemoveByPrefixAsync(CompanyCacheDefaults.PREFIX);
        await base.ClearCacheAsync(entity, entityEventType);
    }

}
