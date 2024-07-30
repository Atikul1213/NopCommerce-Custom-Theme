using Nop.Core;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Domains;
public class ShareMedia : BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
    public int IconId { get; set; }

    internal ShareMediaModel MapTo(ShareMediaModel model)
    {
        throw new NotImplementedException();
    }
}
