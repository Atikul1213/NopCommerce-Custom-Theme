using Nop.Core;
using Nop.Core.Domain.Localization;

namespace Nop.Plugin.Widgets.NopQuickTabs.Domains;
public class Tab : BaseEntity, ILocalizedEntity
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
