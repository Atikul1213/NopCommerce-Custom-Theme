using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.ShareOptions;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Validators;
public partial  class ShareOptionValidator : BaseNopValidator<ShareOptionModel>
{
    public ShareOptionValidator(ILocalizationService localizationService)
    {

        RuleFor(x=>x.zone).NotEmpty().NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.ShareMediaOption.ShareOption.Fields.zone.Required"));
        SetDatabaseValidationRules<ShareOption>();
    }

}
