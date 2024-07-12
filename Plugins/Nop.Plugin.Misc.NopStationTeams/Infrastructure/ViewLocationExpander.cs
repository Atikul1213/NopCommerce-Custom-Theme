using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Core.Infrastructure;
using Nop.Web.Framework;
using Nop.Web.Framework.Themes;

namespace Nop.Plugin.Misc.NopStationTeams.Infrastructure;
public partial class ViewLocationExpander : IViewLocationExpander
{
    protected const string THEME_KEY = "nop.themename";
    public void PopulateValues(ViewLocationExpanderContext context)
    {

        context.Values[THEME_KEY] = EngineContext.Current.Resolve<IThemeContext>().GetWorkingThemeNameAsync().Result;
    }

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        if(context.AreaName == "Admin")
        {
            viewLocations = new string[]
            {
                $"/Plugins/Misc.NopStationTeams/Areas/Admin/Views/{{0}}.cshtml",
                $"/Plugins/Misc.NopStationTeams/Areas/Admin/Views/{{1}}/{{0}}.cshtml"
            }.Concat(viewLocations);
        }
        else
        {

            viewLocations = new string[] {
                    $"/Plugins/Misc.NopStationTeams/Views/Shared/{{0}}.cshtml",
                    $"/Plugins/Misc.NopStationTeams/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);

            if (context.Values.TryGetValue(THEME_KEY, out string theme))
            {
                viewLocations = new string[]
                {

                    $"/Plugins/Misc.NopStationTeams/Themes/{theme}/Views/Shared/{{0}}.cshtml",
                    $"/Plugins/Misc.NopStationTeams/Themes/{theme}/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations); 
            }

        }


        return viewLocations;

    }

}
