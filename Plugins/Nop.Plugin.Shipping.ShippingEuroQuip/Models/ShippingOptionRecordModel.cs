using Nop.Web.Framework.Models;

namespace Nop.Plugin.Shipping.ShippingEuroQuip.Models;
public record ShippingOptionRecordModel : BaseNopModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string CompanyName { get; set; }
    public string IdealCollationTime { get; set; }
    public string Message { get; set; }
}
