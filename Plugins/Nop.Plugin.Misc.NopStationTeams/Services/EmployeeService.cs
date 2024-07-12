using Nop.Core;
using Nop.Data;
using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Services.Configuration;

namespace Nop.Plugin.Misc.NopStationTeams.Services;
public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly ISettingService _settingService;
    private readonly EmployeeSettings _employeeSettings;

    public EmployeeService(IRepository<Employee> employeeRepository, ISettingService settingService, EmployeeSettings employeeSettings)
    {
        _employeeRepository = employeeRepository;
        _settingService = settingService;
        _employeeSettings = employeeSettings;
    }

    public virtual async Task InsertEmployeeAsync(Employee employee)
    {
        await _employeeRepository.InsertAsync(employee);
    }

    public virtual async Task UpdateEmployeeAsync(Employee employee)
    {
        await _employeeRepository.UpdateAsync(employee);
    }

    public virtual async Task DeleteEmployeeAsync(Employee employee)
    {
        await _employeeRepository.DeleteAsync(employee);
    }

    public virtual async Task<Employee> GetEmployeeByIdAsync(int employeeId)
    {
        return await _employeeRepository.GetByIdAsync(employeeId);
    }


    public virtual async Task<IPagedList<Employee>> SearchEmployeesAsync(string name, int statusId,int pageIndex = 0, int pageSize = int.MaxValue)
    {
        
        //var employee = await _settingService.GetAllSettingsAsync();
/*

        if (_employeeSettings.IsMVP)
        {
            var query = from e in _employeeRepository.Table
                        where e.IsMVP == true
                        select e;
                
            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        if(_employeeSettings.IsCertified)
        {
            var query = from e in _employeeRepository.Table
                        where e.IsCertified == true
                        select e;

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


        if(_employeeSettings.IsMVP==false && _employeeSettings.IsCertified == false)
        {
            var query = from e in _employeeRepository.Table
                        where e.IsMVP == false && e.IsCertified == false
                        select e;

            

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }
         */


            var query = from e in _employeeRepository.Table
                        select e;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(e => e.Name.Contains(name));
            if (statusId > 0)
                query = query.Where(e => e.EmployeeStatusId == statusId);
            query = query.OrderBy(e => e.Name);

            return await query.ToPagedListAsync(pageIndex, pageSize);

    }

     

}
