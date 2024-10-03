using FluentValidation;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Validators;
public partial class ShareMediaValidator : BaseNopValidator<ShareMediaModel>
{
    public ShareMediaValidator(ILocalizationService localizationService)
    {

        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Widget.SocialMediaSharing.Model.Name.Required"));
        RuleFor(x => x.Url).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Widget.SocialMediaSharing.Model.Url.Required"));
        
        SetDatabaseValidationRules<ShareMedia>();
    }
}
