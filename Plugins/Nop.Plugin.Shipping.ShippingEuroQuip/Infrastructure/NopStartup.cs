using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Shipping.EuroQuip.Factories;
using Nop.Plugin.Shipping.EuroQuip.Services;

namespace Nop.Plugin.Shipping.EuroQuip.Infrastructure;
public class NopStartup : INopStartup
{
    public int Order => 3000;

    public void Configure(IApplicationBuilder application)
    {

    }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPickUpServices, PickUpServices>();
        services.AddScoped<IPickupDetailModelFactory, PickupDetailModelFactory>();
    }
}
