using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Web.Framework;

namespace Nop.Plugin.Misc.EmployeeManager.Infrastructure;
public class ViewLocationExpander : IViewLocationExpander
{
    const string PLUGIN_NAME = "Misc.EmployeeManager";
    const string THEME_KEY = "nop.themename";

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        if (context.AreaName == AreaNames.ADMIN)
            viewLocations = new[] {
                    $"/Plugins/{PLUGIN_NAME}/Areas/Admin/Views/{{1}}/{{0}}.cshtml",
                    $"/Plugins/{PLUGIN_NAME}/Areas/Admin/Views/Shared/{{0}}.cshtml"
                }.Concat(viewLocations);
        else
        {
            viewLocations = new[] {
                    $"/Plugins/{PLUGIN_NAME}/Views/{{1}}/{{0}}.cshtml",
                    $"/Plugins/{PLUGIN_NAME}/Views/Shared/{{0}}.cshtml"
                }.Concat(viewLocations);

            if (context.Values.TryGetValue(THEME_KEY, out var theme))
                viewLocations = new[] {
                        $"/Plugins/{PLUGIN_NAME}/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
                        $"/Plugins/{PLUGIN_NAME}/Themes/{theme}/Views/Shared/{{0}}.cshtml"
                    }.Concat(viewLocations);
        }

        return viewLocations;
    }

    public void PopulateValues(ViewLocationExpanderContext context)
    { }
}
