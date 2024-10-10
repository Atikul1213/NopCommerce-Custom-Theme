using System;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace NopStation.Plugin.Widgets.AddCrawlers.Models
{
    public record CrawlerModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Plugins.Widgets.AddCrawlers.Fields.CrawlerInfo")]
        public string CrawlerInfo { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AddCrawlers.Fields.IPAddress")]
        public string IPAddress { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AddCrawlers.Fields.Location")]
        public string Location { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AddCrawlers.Fields.AddedOnUtc")]
        public DateTime AddedOnUtc { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AddCrawlers.Fields.AddedBy")]
        public string AddedBy { get; set; }
    }
}