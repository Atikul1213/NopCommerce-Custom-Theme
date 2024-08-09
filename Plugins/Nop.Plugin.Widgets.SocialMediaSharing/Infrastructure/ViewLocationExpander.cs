using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Themes;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Infrastructure;
public partial class ViewLocationExpander : IViewLocationExpander
{
    protected const string THEME_KEY = "nop.themename";
    public void PopulateValues(ViewLocationExpanderContext context)
    {
        context.Values[THEME_KEY] = EngineContext.Current.Resolve<IThemeContext>().GetWorkingThemeNameAsync().Result;
    }


    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        if(context.AreaName=="Admin")
        {
            viewLocations = new string[]
            {
                $"~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/{{0}}.cshtml",
                $"~/Plugins/Widgets.SocialMediaSharing/Areas/Admin/Views/{{1}}/{{0}}.cshtml"
            }.Concat(viewLocations);
        }

        else
        {
            viewLocations = new string[]
            {
                $"~/Plugins/Widgets.SocialMediaSharing/Views/Shared/{{0}}.cshtml",
                $"~/Plugins/Widgets.SocialMediaSharing/Views/{{1}}/{{0}}.cshtml"
            }.Concat(viewLocations);

           


        }

        return viewLocations;

    }

}
