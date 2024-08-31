using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Misc.EmployeeManager.Common;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.EmployeeManager.Models;
public record EmployeeSearchModel : BaseSearchModel
{
    public EmployeeSearchModel()
    {
        Start = 0;
        Length = 5;
        AvailablePageSizes = "5,10,15";
    }

    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_FIRSTNAME)]
    public string? Firstname { get; set; }

    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_LASTNAME)]
    public string? Lastname { get; set; }

    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_PHONENUMBER)]
    public string? Phonenumber { get; set; }

    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_EMPLOYEE_TYPE)]
    public int EmployeeType { get; set; } = -1;

    [NopResourceDisplayName(EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_INCLUDE_INACTIVE)]
    //[DefaultValue(false)]
    public bool IncludeInactive { get; set; }
}
