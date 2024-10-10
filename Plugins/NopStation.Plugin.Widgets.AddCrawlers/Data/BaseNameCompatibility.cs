using System;
using System.Collections.Generic;
using Nop.Data.Mapping;
using NopStation.Plugin.Widgets.AddCrawlers.Domain;

namespace NopStation.Plugin.Widgets.AddCrawlers.Data
{
    public class BaseNameCompatibility : INameCompatibility
    {
        public Dictionary<Type, string> TableNames => new Dictionary<Type, string>
        {
            { typeof(Crawler), "NS_Crawler" },
        };

        public Dictionary<(Type, string), string> ColumnName => new()
        {
        };
    }
}
