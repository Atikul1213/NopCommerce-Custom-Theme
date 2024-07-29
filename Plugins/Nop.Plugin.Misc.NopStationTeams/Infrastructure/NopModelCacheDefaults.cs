using Nop.Core.Caching;

namespace Nop.Plugin.Misc.NopStationTeams.Infrastructure;
public static partial class NopModelCacheDefaults
{
    public static CacheKey AdminEmployeeAllModelKey => new("AdminEmployeeList",AdminEmployeeAllPrefixCacheKey);

    public static string AdminEmployeeAllPrefixCacheKey => "Nop.Plugin.Misc.NopStationTeams.Admin";


    public static CacheKey PublicEmployeeAllModelKey => new("PublicEmployeeList", PublicEmployeeAllPrefixCacheKey);
    public static string PublicEmployeeAllPrefixCacheKey => "Nop.Plugin.Misc.NopStationTeams.Public";
}
