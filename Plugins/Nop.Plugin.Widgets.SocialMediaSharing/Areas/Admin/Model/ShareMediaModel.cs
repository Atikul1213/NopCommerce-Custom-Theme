using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model;
public record ShareMediaModel : BaseNopEntityModel
{
    // [BindNever]
    // [NopResourceDisplayName("Admin.Widget.SocialMediaSharing.Model.Id")]
    // public override int Id { get; set; }
    public ShareMediaModel()
    {
        
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
   
}
