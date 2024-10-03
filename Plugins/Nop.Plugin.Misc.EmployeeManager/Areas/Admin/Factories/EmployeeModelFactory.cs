using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExCSS;
using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Plugin.Misc.EmployeeManager.Domain;
using Nop.Plugin.Misc.EmployeeManager.Models;
using Nop.Plugin.Misc.EmployeeManager.Services;
using Nop.Services.Common;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Common;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Misc.EmployeeManager.Areas.Admin.Factories;

public class EmployeeModelFactory : IEmployeeModelFactory
{
    private readonly IEmployeeService _employeeService;
    private readonly IAddressService _addressService;
    private readonly IAddressModelFactory _addressModelFactory;

    public EmployeeModelFactory(IEmployeeService employeeService,
        IAddressService addressService,
        IAddressModelFactory addressModelFactory)
    {
        _employeeService = employeeService;
        _addressService = addressService;
        _addressModelFactory = addressModelFactory;
    }

    public async Task<EmployeeEntity> PrepareEmployeeEntity(EmployeeModel employeeModel)
    {
        EmployeeEntity employeeEntity = employeeModel.ToEntity<EmployeeEntity>();
        employeeEntity.IsActive = true;
        return employeeEntity;
    }

    public async Task<EmployeeModel> PrepareEmployeeModel(int employeeId = 0)
    {
        if (employeeId > 0)
        {
            EmployeeEntity employeeEntity = await _employeeService.GetEmployeeById(employeeId);
            return employeeEntity.ToModel<EmployeeModel>();
        }

        return new EmployeeModel();
    }

    public async Task<EmployeeAddressModel> PrepareEmployeeAddressModel(EmployeeAddressModel employeeAddressModel, int employeeId = 0)
    {
        if (employeeId > 0)
        {
            EmployeeAddressMapping employeeAddress = await _employeeService.GetEmployeeAddressByEmployeeId(employeeId);
            EmployeeModel employeeModel = await PrepareEmployeeModel(employeeId);
            Address address = await _addressService.GetAddressByIdAsync(employeeAddress.AddressId);
            AddressModel addressModel = address.ToModel<AddressModel>();
            await _addressModelFactory.PrepareAddressModelAsync(addressModel, address);

            employeeAddressModel.Employee = employeeModel;
            employeeAddressModel.Address = addressModel;

            return employeeAddressModel;
        }

        if (employeeAddressModel.Address is null)
        {
            employeeAddressModel.Address = new AddressModel();
        }
        await _addressModelFactory.PrepareAddressModelAsync(employeeAddressModel.Address);
        employeeAddressModel.Employee = await PrepareEmployeeModel();

        return employeeAddressModel;
    }

    public async Task<EmployeePagedListModel> PrepareEmployeePagedListModel(EmployeeSearchModel? searchModel = null)
    {
        if (searchModel is null)
        {
            searchModel = await PrepareEmployeeSearchModel();
        }

        IPagedList<EmployeeEntity> employeeEntities = await _employeeService.GetAllEmployeePaged(searchModel);

        Func<IEnumerable<EmployeeModel>> employeeEntitiesToModelsConverter = () => employeeEntities.Select(employee => employee.ToModel<EmployeeModel>());

        var employeeListModel = new EmployeePagedListModel()
            .PrepareToGrid(searchModel, employeeEntities, employeeEntitiesToModelsConverter);

        return employeeListModel;
    }

    public async Task<EmployeeSearchModel> PrepareEmployeeSearchModel(EmployeeSearchModel? searchModel = null)
    {
        if (searchModel is null)
        {
            searchModel = new EmployeeSearchModel();
        }

        if (searchModel.Firstname is null)
        {
            searchModel.Firstname = string.Empty;
        }
        searchModel.Firstname = searchModel.Firstname.Trim();

        if (searchModel.Lastname is null)
        {
            searchModel.Lastname = string.Empty;
        }
        searchModel.Lastname = searchModel.Lastname.Trim();

        if (searchModel.Phonenumber is null)
        {
            searchModel.Phonenumber = string.Empty;
        }
        searchModel.Phonenumber = searchModel.Phonenumber.Trim();

        return searchModel;
    }
}
