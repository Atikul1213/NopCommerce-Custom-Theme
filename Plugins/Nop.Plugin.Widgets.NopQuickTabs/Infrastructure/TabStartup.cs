﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Services;

namespace Nop.Plugin.Widgets.NopQuickTabs.Infrastructure;
public class TabStartup : INopStartup
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


        services.AddScoped<ITabService, TabService>();
        services.AddScoped<ITabModelFactorie, TabModelFactories>();
        services.AddScoped<ITabHomeModelFactory, TabHomeModelFactory>();

    }
}
