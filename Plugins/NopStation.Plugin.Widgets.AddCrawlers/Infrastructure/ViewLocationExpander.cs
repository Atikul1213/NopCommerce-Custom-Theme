using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Themes;

namespace Nop.Plugin.Widgets.Demo.Infrastructure;
public class ViewLocationExpander : IViewLocationExpander
{
    protected const string THEME_KEY = "nop.themename";
    public void PopulateValues(ViewLocationExpanderContext context)
    {
        context.Values[THEME_KEY] = EngineContext.Current.Resolve<IThemeContext>().GetWorkingThemeNameAsync().Result;
    }


    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        if (context.AreaName == "Admin")
        {
            viewLocations = new string[]
           {
                $"/Plugins/Widgets.Demo/Areas/Admin/Views/Shared/{{0}}.cshtml",
                $"/Plugins/Widgets.Demo/Areas/Admin/Views/{{1}}/{{0}}.cshtml"
           }.Concat(viewLocations);

        }

        else
        {
            viewLocations = new string[]
            {
                $"~/Plugins/Widgets.Demo/Views/Shared/{{0}}.cshtml",
                $"~/Plugins/Widgets.Demo/Views/{{1}}/{{0}}.cshtml"
            }.Concat(viewLocations);

            if (context.Values.TryGetValue(THEME_KEY, out string theme))
            {
                viewLocations = new string[]
                {
                    $"/Plugins/Widgets.Demo/Themes/{theme}/Views/Shared/{{0}}.cshtml",

                    $"/Plugins/Widgets.Demo/Themes/{theme}/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);
            }


        }

        return viewLocations;

    }
}
