using Nop.Core.Caching;

namespace Nop.Plugin.Misc.NopStationTeams.Infrastructure;
public static partial class NopModelCacheDefaults
{
    public static CacheKey AdminEmployeeAllModelKey => new("Nop.Plugin.Misc.NopStationTeams.Admin.{0}-{1}-{2}", AdminEmployeeAllPrefixCacheKey);

    public static string AdminEmployeeAllPrefixCacheKey => "Nop.Plugin.Misc.NopStationTeams.Admin";


    public static CacheKey PublicEmployeeAllModelKey => new("Nop.Plugin.Misc.NopStationTeams.Public.{0}-{1}-{2}", PublicEmployeeAllPrefixCacheKey);
    public static string PublicEmployeeAllPrefixCacheKey => "Nop.Plugin.Misc.NopStationTeams.Public";
}
