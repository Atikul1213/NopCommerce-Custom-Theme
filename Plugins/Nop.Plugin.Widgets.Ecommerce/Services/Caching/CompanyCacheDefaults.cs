using Nop.Core.Caching;

namespace Nop.Plugin.Widgets.Ecommerce.Services.Caching;
public static class CompanyCacheDefaults
{
    public const string PREFIX = "Nop.Plugin.Widget.Ecommerce.Company.Caching.CompanyCacheDefaults";

    #region COMPANY TYPE MAPPING CACHING 

    public static CacheKey GetAllCompanyAsync = new
        (
            "Nop.Plugin.Widget.Ecommerce.Company.Caching.CompanyCacheDefaults.GetAllCompanyAsync", PREFIX
        );



    #endregion
}
