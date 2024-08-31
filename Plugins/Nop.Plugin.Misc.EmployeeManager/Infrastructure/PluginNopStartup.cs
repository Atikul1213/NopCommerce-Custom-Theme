using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.EmployeeManager.Areas.Admin.Factories;
using Nop.Plugin.Misc.EmployeeManager.Services;

namespace Nop.Plugin.Misc.EmployeeManager.Infrastructure;
public class PluginNopStartup : INopStartup
{
    public int Order => 1;

    public void Configure(IApplicationBuilder application)
    { }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.ViewLocationExpanders.Add(new ViewLocationExpander());
        });

        services.AddScoped<IEmployeeModelFactory, EmployeeModelFactory>();
        services.AddScoped<IEmployeeService, EmployeeService>();
    }
}
