using Nop.Core;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Domains;
public class ShareOption : BaseEntity
{
    public int ShareMediaId { get; set; }
    public string CustomMessage { get; set; }
    public string Zone { get; set; }

}
