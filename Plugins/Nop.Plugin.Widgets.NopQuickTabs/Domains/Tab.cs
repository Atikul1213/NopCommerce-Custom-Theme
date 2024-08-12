using Nop.Core;

namespace Nop.Plugin.Widgets.NopQuickTabs.Domains;
public class Tab : BaseEntity
{
    public int ProductId { get; set; }
    public string SystemName { get; set; }

    public string DisplayName { get; set; }
    public string Description { get; set; }
    public bool LimitedToStores { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsEnable { get; set; }

}
