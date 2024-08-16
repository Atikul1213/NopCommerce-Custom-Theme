using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Themes;

namespace Nop.Plugin.Widgets.NopQuickTabs.Infrastructure;
public partial class ViewLocationExpander : IViewLocationExpander
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
                $"/Plugins/Widgets.NopQuickTabs/Areas/Admin/Views/Shared/{{0}}.cshtml",
                //$"/Plugins/Widgets.NopQuickTabs/Areas/Admin/Views/Shared/Components/{{0}}.cshtml",
                $"/Plugins/Widgets.NopQuickTabs/Areas/Admin/Views/{{1}}/{{0}}.cshtml"
            }.Concat(viewLocations);
        }

        else
        {
            viewLocations = new string[]
            {
                $"/Plugins/Widgets.NopQuickTabs/Views/Shared/{{0}}.cshtml",
                //$"/Plugins/Widgets.NopQuickTabs/Views/Shared/Components/{{0}}.cshtml",
                $"/Plugins/Widgets.NopQuickTabs/Views/{{1}}/{{0}}.cshtml"
            }.Concat(viewLocations);


            if (context.Values.TryGetValue(THEME_KEY, out string theme))
            {
                viewLocations = new string[]
                {
                    $"/Plugins/Widgets.NopQuickTabs/Themes/{theme}/Views/Shared/{{0}}.cshtml",
                    $"/Plugins/Widgets.NopQuickTabs/Themes/{theme}/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);
            }

        }

        return viewLocations;
    }

}
