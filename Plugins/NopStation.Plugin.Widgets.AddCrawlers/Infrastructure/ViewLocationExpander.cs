using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Themes;

namespace NopStation.Plugin.Widgets.AddCrawlers.Infrastructure;
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
                $"/Plugins/NopStation.Plugin.Widgets.AddCrawlers/Areas/Admin/Views/Shared/{{0}}.cshtml",
                $"/Plugins/NopStation.Plugin.Widgets.AddCrawlers/Areas/Admin/Views/{{1}}/{{0}}.cshtml"
           }.Concat(viewLocations);

        }

        else
        {
            viewLocations = new string[]
            {
                $"~/Plugins/NopStation.Plugin.Widgets.AddCrawlers/Views/Shared/{{0}}.cshtml",
                $"~/Plugins/NopStation.Plugin.Widgets.AddCrawlers/Views/{{1}}/{{0}}.cshtml"
            }.Concat(viewLocations);

            if (context.Values.TryGetValue(THEME_KEY, out string theme))
            {
                viewLocations = new string[]
                {
                    $"/Plugins/NopStation.Plugin.Widgets.AddCrawlers/Themes/{theme}/Views/Shared/{{0}}.cshtml",

                    $"/Plugins/NopStation.Plugin.Widgets.AddCrawlers/Themes/{theme}/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);
            }


        }

        return viewLocations;

    }
}
