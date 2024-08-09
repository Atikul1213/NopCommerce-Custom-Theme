using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Factories;
using Nop.Plugin.Widgets.SocialMediaSharing.Factories;
using Nop.Plugin.Widgets.SocialMediaSharing.Services;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Infrastructure;
public class ShareStartup : INopStartup
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


        services.AddScoped<IShareMediaService, ShareMediaService>();
        services.AddScoped<IShareMediaModelFactory, ShareMediaModelFactory>();
        services.AddScoped<IShareOptionService, ShareOptionService>();
        services.AddScoped<IShareOptionModelFactory, ShareOptionModelFactory>();
        services.AddScoped<ISocialMediaHomeModelFactory, SocialMediaHomeModelFactory>();
        

    }
}
