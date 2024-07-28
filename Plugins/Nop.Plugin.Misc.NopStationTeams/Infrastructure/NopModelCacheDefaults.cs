using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Caching;

namespace Nop.Plugin.Misc.NopStationTeams.Infrastructure;
public static partial class NopModelCacheDefaults
{
    public static CacheKey AdminEmployeeAllModelKey => new("AdminEmployeeList",AdminEmployeeAllPrefixCacheKey);

    public static string AdminEmployeeAllPrefixCacheKey => "Nop.Plugin.Misc.NopStationTeams";


    public static CacheKey PublicEmployeeAllModelKey => new("PUblicEmployeeList", PublicEmployeeAllPrefixCacheKey);
    public static string PublicEmployeeAllPrefixCacheKey => "Nop.Plugin.Misc.NopStationTeams";
}
