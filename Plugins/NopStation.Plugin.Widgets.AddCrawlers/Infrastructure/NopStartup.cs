using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using NopStation.Plugin.Misc.Core.Infrastructure;
using NopStation.Plugin.Widgets.AddCrawlers.Factories;
using NopStation.Plugin.Widgets.AddCrawlers.Services;

namespace NopStation.Plugin.Widgets.AddCrawlers.Infrastructure
{
    public class NopStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICrawlerService, CrawlerService>();

            services.AddScoped<ICrawlerFactory, CrawlerFactory>();

            services.AddNopStationServices("NopStation.Plugin.Widgets.AddCrawlers", true);
        }

        public void Configure(IApplicationBuilder application)
        {
        }

        public int Order => 3000;
    }
}
