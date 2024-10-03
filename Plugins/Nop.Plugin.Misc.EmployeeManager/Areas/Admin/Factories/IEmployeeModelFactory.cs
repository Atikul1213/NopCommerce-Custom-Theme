using Nop.Plugin.Misc.EmployeeManager.Domain;
using Nop.Plugin.Misc.EmployeeManager.Models;

namespace Nop.Plugin.Misc.EmployeeManager.Areas.Admin.Factories;

public interface IEmployeeModelFactory
{
    Task<EmployeeEntity> PrepareEmployeeEntity(EmployeeModel employeeModel);
    Task<EmployeeModel> PrepareEmployeeModel(int employeeId = 0);
    Task<EmployeeAddressModel> PrepareEmployeeAddressModel(EmployeeAddressModel employeeAddressModel, int employeeId = 0);
    Task<EmployeePagedListModel> PrepareEmployeePagedListModel(EmployeeSearchModel? searchModel = null);
    Task<EmployeeSearchModel> PrepareEmployeeSearchModel(EmployeeSearchModel? searchModel = null);
}
