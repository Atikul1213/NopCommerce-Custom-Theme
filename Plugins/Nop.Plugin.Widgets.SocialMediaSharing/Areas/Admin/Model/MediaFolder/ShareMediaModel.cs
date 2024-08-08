using System.ComponentModel.DataAnnotations;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

public record ShareMediaModel : BaseNopEntityModel
{
    public ShareMediaModel()
    {
        ShareOptionSearchModel = new ShareOptionSearchModel();
        
    }

    [NopResourceDisplayName("Admin.Widget.SocialMediaSharing.Model.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Widget.SocialMediaSharing.Model.Url")]
    public string Url { get; set; }

    [NopResourceDisplayName("Admin.Widget.SocialMediaSharing.Model.DisplayOrder")]
    public int DisplayOrder { get; set; }

    [NopResourceDisplayName("Admin.Widget.SocialMediaSharing.Model.IsActive")]
    public bool IsActive { get; set; }

    [NopResourceDisplayName("Admin.Widget.SocialMediaSharing.Model.IconId")]
    [UIHint("Picture")]
    public int IconId { get; set; }

    [NopResourceDisplayName("Admin.Widget.SocialMediaSharing.Model.Icon")]
    public string IconThumbnailUrl { get; set; }

    public ShareOptionSearchModel ShareOptionSearchModel { get; set; }

}
