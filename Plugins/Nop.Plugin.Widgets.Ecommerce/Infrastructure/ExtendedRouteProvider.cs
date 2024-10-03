using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using Nop.Web.Infrastructure;

namespace Nop.Plugin.Widgets.Ecommerce.Infrastructure;
public partial class ExtendedRouteProvider : BaseRouteProvider, IRouteProvider
{
    public int Priority => 1;

    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        var lang = GetLanguageRoutePattern();

        //endpointRouteBuilder.MapControllerRoute(name: "Checkout",
        //    pattern: $"{lang}/checkout",
        //    defaults: new { controller = "CustomCheckout", action = "ShippingMethod" });
    }
}
