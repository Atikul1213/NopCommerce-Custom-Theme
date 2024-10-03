using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Misc.EmployeeManager.Domain;
public class EmployeeAddressMapping : BaseEntity
{
    public int EmployeeId { get; set; }
    public int AddressId { get; set; }
}
