using Nop.Web.Framework.Models;
using Nop.Web.Models.Media;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Models;
public record SocialMediaHomeModel : BaseNopEntityModel
{
    public string Name { get; set; }
    public PictureModel Icon { get; set; }
    public string Url { get; set; }
    public string CustomMessage { get; set; }

}
