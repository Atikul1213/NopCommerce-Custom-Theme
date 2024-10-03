using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Data;
using Nop.Plugin.Misc.EmployeeManager.Common;
using Nop.Plugin.Misc.EmployeeManager.Domain;
using Nop.Plugin.Misc.EmployeeManager.Models;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Common;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Misc.EmployeeManager.Services;

public interface IEmployeeService
{
    Task<IPagedList<EmployeeEntity>> GetAllEmployeePaged(EmployeeSearchModel searchModel);
    Task<EmployeeEntity> GetEmployeeById(int id);
    Task InsertAsync(EmployeeEntity employeeEntity);
    Task MapEmployeeAddressAsync(EmployeeAddressMapping employeeAddress);
    Task<EmployeeAddressMapping> GetEmployeeAddressByEmployeeId(int employeeId);
    Task UpdateEmployeeAsync(EmployeeEntity employeeEntity);
    Task DeleteEmployeesAsync(ICollection<int> employeeIds);
}

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<EmployeeEntity> _employeeEntityRepository;
    private readonly IRepository<Address> _addressRepository;
    private readonly IRepository<EmployeeAddressMapping> _employeeAddressRepository;

    public EmployeeService(IRepository<EmployeeEntity> employeeEntityRepository,
        IRepository<EmployeeAddressMapping> employeeAddressRepository,
        IRepository<Address> addressRepository)
    {
        _employeeEntityRepository = employeeEntityRepository;
        _employeeAddressRepository = employeeAddressRepository;
        _addressRepository = addressRepository;
    }

    public async Task<IPagedList<EmployeeEntity>> GetAllEmployeePaged(EmployeeSearchModel searchModel)
    {
        var employees = await _employeeEntityRepository.GetAllPagedAsync(query =>
        {
            query = query.Where(e => e.Firstname.Contains(searchModel.Firstname!, StringComparison.CurrentCultureIgnoreCase));
            query = query.Where(e => e.Lastname.Contains(searchModel.Lastname!, StringComparison.CurrentCultureIgnoreCase));
            query = query.Where(e => e.Phonenumber.Contains(searchModel.Phonenumber!, StringComparison.CurrentCultureIgnoreCase));

            var employeeType = (EmployeeType)searchModel.EmployeeType!;
            if (Enum.IsDefined(employeeType))
            {
                query = query.Where(e => e.EmployeeType == employeeType);
            }

            if (!searchModel.IncludeInactive)
            {
                query = query.Where(e => e.IsActive);
            }

            return query;
        }, searchModel.Page - 1, searchModel.PageSize);

        return employees;
    }

    public async Task<EmployeeEntity> GetEmployeeById(int id)
    {
        return await _employeeEntityRepository.GetByIdAsync(id);
    }

    public async Task<EmployeeAddressMapping> GetEmployeeAddressByEmployeeId(int employeeId)
    {
        EmployeeAddressMapping employeeAddress = await _employeeAddressRepository.Table.FirstOrDefaultAsync(employeeAddress => employeeAddress.EmployeeId == employeeId);
        return employeeAddress;
    }

    public async Task InsertAsync(EmployeeEntity employeeEntity)
    {
        await _employeeEntityRepository.InsertAsync(employeeEntity);
    }

    public async Task MapEmployeeAddressAsync(EmployeeAddressMapping employeeAddress)
    {
        await _employeeAddressRepository.InsertAsync(employeeAddress);
    }

    public async Task UpdateEmployeeAsync(EmployeeEntity employeeEntity)
    {
        await _employeeEntityRepository.UpdateAsync(employeeEntity);
    }

    public async Task DeleteEmployeesAsync(ICollection<int> employeeIds)
    {
        var empAddresses = _employeeAddressRepository.Table
            .Where(ea => employeeIds.Contains(ea.EmployeeId));

        var addresses = empAddresses.InnerJoin(_addressRepository.Table, (EmployeeAddressMapping eam, Address add) => eam.AddressId == add.Id, (employeeAddress, address) => address);

        await empAddresses.DeleteAsync();
        await addresses.DeleteAsync();
        await _employeeEntityRepository.Table.Where(em => employeeIds.Contains(em.Id)).DeleteAsync();
    }
}
