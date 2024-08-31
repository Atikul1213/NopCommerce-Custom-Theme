using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using Nop.Services.Security;

namespace Nop.Plugin.Misc.EmployeeManager.Services.Security;
public class EmployeeManagerPermissionProvider : IPermissionProvider
{
    public static readonly PermissionRecord ManageEmployees = new() { Name = "Admin area. Manage Employees", SystemName = "ManageEmployees", Category = "EmployeeManager" };

    public HashSet<(string systemRoleName, PermissionRecord[] permissions)> GetDefaultPermissions()
    {
        return new HashSet<(string systemRoleName, PermissionRecord[] permissions)>
        {
            (NopCustomerDefaults.AdministratorsRoleName, new[]
            {
                ManageEmployees
            })
        };
    }

    public IEnumerable<PermissionRecord> GetPermissions()
    {
        return new[]
        {
            ManageEmployees
        };
    }
}
