using System.ComponentModel.DataAnnotations;
using Nop.Plugin.Misc.EmployeeManager.Common;
using Nop.Web.Areas.Admin.Models.Common;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.EmployeeManager.Models;

public record EmployeeModel : BaseNopEntityModel
{
    [Required]
    [MinLength(1)]
    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_FIRSTNAME)]
    public string Firstname { get; set; }

    [Required]
    [MinLength(1)]
    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_LASTNAME)]
    public string Lastname { get; set; }

    [Required]
    [Phone]
    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_PHONENUMBER)]
    public string Phonenumber { get; set; }

    [Required]
    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_EMPLOYEE_TYPE)]
    public EmployeeType EmployeeType { get; set; }
    public string EmployeeTypeLabel
    {
        get => EmployeeType.ToString();
    }

    [Required]
    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_IS_ACTIVE)]
    public bool IsActive { get; set; }
}

public record EmployeeAddressModel : BaseNopEntityModel
{

    [Required]
    public EmployeeModel Employee { get; set; }

    [Required]
    public AddressModel Address { get; set; }
}
