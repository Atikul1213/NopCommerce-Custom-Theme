using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.CompanyFactory;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Factories.ProductBrochureFactory;
using Nop.Plugin.Widgets.Ecommerce.Factories.ProductBrochure;
using Nop.Plugin.Widgets.Ecommerce.Services.CompanyServices;
using Nop.Plugin.Widgets.Ecommerce.Services.ProductBrochureAttach;

namespace Nop.Plugin.Widgets.Ecommerce.Infrastructure;
public class PluginNopStartup : INopStartup
{
    public int Order => 3000;

    public void Configure(IApplicationBuilder application)
    {

    }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.ViewLocationExpanders.Add(new ViewLocationExpander());
        });

        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICompanyModelFactory, CompanyModelFactory>();
        services.AddScoped<IProductBrochureService, ProductBrochureService>();
        services.AddScoped<IProductBrochureModelFactory, ProductBrochureModelFactory>();
        services.AddScoped<IProductBrochureInfoModelFactory, ProductBrochureInfoModelFactory>();


    }

}
