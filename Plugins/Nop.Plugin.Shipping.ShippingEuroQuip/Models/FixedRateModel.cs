using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Shipping.EuroQuip.Models;
public record FixedRateModel : BaseNopModel
{

    public int ShippingMethodId { get; set; }

    [NopResourceDisplayName("Nop.Plugin.Shipping.EuroQuip.Models.FixedRateModel.Fields.ShippingMethodName")]
    public string ShippingMethodName { get; set; }

    [NopResourceDisplayName("Nop.Plugin.Shipping.EuroQuip.Models.FixedRateModel.Fields.Rate")]

    public decimal Rate { get; set; }

    [UIHint("Int32Nullable")]

    [NopResourceDisplayName("Nop.Plugin.Shipping.EuroQuip.Models.FixedRateModel.Fields.IsPickUp")]
    public bool? IsPickUp { get; set; }
}
