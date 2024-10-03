using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
public static class WidgetZoneHelper
{
    public static IList<SelectListItem> GetAllWidgetZone()
    {
        var widgetZone = new List<SelectListItem>();
        var properties = typeof(PublicWidgetZones).GetProperties(BindingFlags.Public | BindingFlags.Static);

        foreach(var property in properties)
        {
            var value = property.GetValue(null)?.ToString();
            if(!string.IsNullOrEmpty(value))
            {
                widgetZone.Add(new SelectListItem { Text = value, Value = value });
            }
        }
        return widgetZone;
    }

}
