using Nop.Data.Mapping;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Data;
public class BaseNameCompatibility : INameCompatibility
{
    public Dictionary<Type, string> TableNames => new Dictionary<Type, string>
    {
        { typeof(Company), "NS_Company" },
        { typeof(ProductBrochure), "NS_ProductBrochure" },

    };

    public Dictionary<(Type, string), string> ColumnName => new Dictionary<(Type, string), string>
    {
    };
}
