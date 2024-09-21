using Nop.Core.Caching;

namespace Nop.Plugin.Widgets.Ecommerce.Services.Caching;
public static class CompanyCacheDefaults
{
    public const string COMPANY_ADMIN_PREFIX = "Nop.Plugin.Widget.Ecommerce.Company.Admin";
    public const string COMPANY_PUBLIC_PREFIX = "Nop.Plugin.Widget.Ecommerce.Company.Public";

    #region COMPANY TYPE MAPPING CACHING 

    public static CacheKey AdminCompanyModelKey = new
        (
            "Nop.Plugin.Widget.Ecommerce.Company.Admin.{0}", COMPANY_ADMIN_PREFIX
        );

    public static CacheKey PublicCompanyModelKey = new
    (
        "Nop.Plugin.Widget.Ecommerce.Company.Public.{0}", COMPANY_PUBLIC_PREFIX
     );

    #endregion
}
