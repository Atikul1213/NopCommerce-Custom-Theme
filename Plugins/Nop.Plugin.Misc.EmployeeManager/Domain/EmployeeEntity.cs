using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Misc.EmployeeManager.Common;

namespace Nop.Plugin.Misc.EmployeeManager.Domain;
public class EmployeeEntity : BaseEntity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Phonenumber { get; set; }
    public EmployeeType EmployeeType { get; set; }
    public bool IsActive { get; set; }
    //public int CountryId { get; set; }
    //public int StateProvinceId { get; set; }
    //public string City { get; set; }
    //public string ZipCode { get; set; }
    //public int MyProperty { get; set; }
}
