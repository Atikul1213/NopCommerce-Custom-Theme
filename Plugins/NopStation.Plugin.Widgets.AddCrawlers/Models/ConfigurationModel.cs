using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace NopStation.Plugin.Widgets.AddCrawlers.Models;
public record ConfigurationModel : BaseNopModel
{
    public int ActiveStoreScopeConfiguration { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.AddCrawlers.Fields.IsEnabled")]
    public bool IsEnabled { get; set; }
    public bool IsEnabled_OverrideForStore { get; set; }
}
