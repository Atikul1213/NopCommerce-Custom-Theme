using FluentValidation;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure;
using Nop.Plugin.Widgets.Ecommerce.Domains;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Validators;
public partial class ProductBrochureValidator : BaseNopValidator<ProductBrochureModel>
{
    public ProductBrochureValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.ProductDownloadId)
            .GreaterThan(0)
            .WithMessageAwait(localizationService.GetResourceAsync("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ProductDownloadId.Require"));

        RuleFor(x => x.ButtonText)
            .NotEmpty()
            .When(x => x.ProductDownloadId > 0)
            .WithMessageAwait(localizationService.GetResourceAsync("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ButtonText.Required"));

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessageAwait(localizationService.GetResourceAsync("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ProductId.Required"));

        RuleFor(x => x.DisplayOrder)
            .GreaterThan(0)
            .WithMessageAwait(localizationService.GetResourceAsync("Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.DisplayOrder.Required"));

        SetDatabaseValidationRules<ProductBrochure>();
    }
}
