using Nop.Core;

namespace Nop.Plugin.Widgets.NopQuickTabs.Domains;
public class Tab : BaseEntity
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
    public int ContentType { get; set; }

    public ContentTypes ContentTypes
    {
        get => (ContentTypes)ContentType;
        set => ContentType = (int)value;
    }

}
