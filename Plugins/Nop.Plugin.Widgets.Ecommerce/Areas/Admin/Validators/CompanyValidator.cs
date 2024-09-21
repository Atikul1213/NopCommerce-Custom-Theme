using FluentValidation;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.CompanyModel;
using Nop.Plugin.Widgets.Ecommerce.Domain;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Validators;
public class CompanyValidator : BaseNopValidator<CompanyModel>
{
    public CompanyValidator(ILocalizationService localizationService)
    {
        /*
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Widgets.Ecommerce.Fields.Name.Required"));

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Widgets.Ecommerce.Fields.Description.Required"));
        */
        RuleFor(x => x.PictureId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Widgets.Ecommerce.Fields.Picture.Required"));

        SetDatabaseValidationRules<Company>();
    }

}
