using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Common;
using Nop.Plugin.Misc.EmployeeManager.Areas.Admin.Factories;
using Nop.Plugin.Misc.EmployeeManager.Domain;
using Nop.Plugin.Misc.EmployeeManager.Models;
using Nop.Plugin.Misc.EmployeeManager.Services;
using Nop.Plugin.Misc.EmployeeManager.Services.Security;
using Nop.Services.Common;
using Nop.Services.Directory;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;

namespace Nop.Plugin.Misc.EmployeeManager.Areas.Admin.Controllers;
public class EmployeeManagerAdminController : BaseAdminController
{
    private readonly IEmployeeModelFactory _employeeModelFactory;

    private readonly IEmployeeService _employeeService;
    private readonly IAddressService _addressService;
    private readonly ICountryService _countryService;
    private readonly IStateProvinceService _stateProvinceService;
    private readonly IPermissionService _permissionService;
    private readonly INotificationService _notificationService;

    public EmployeeManagerAdminController(IEmployeeModelFactory employeeModelFactory,
        IEmployeeService employeeService,
        IAddressService addressService,
        ICountryService countryService,
        IStateProvinceService stateProvinceService,
        IPermissionService permissionService,
        INotificationService notificationService)
    {
        _employeeModelFactory = employeeModelFactory;
        _employeeService = employeeService;
        _addressService = addressService;
        _countryService = countryService;
        _stateProvinceService = stateProvinceService;
        _permissionService = permissionService;
        _notificationService = notificationService;
    }

    public async Task<IActionResult> GetStates(int id)
    {
        var stateProvinces = await _stateProvinceService.GetStateProvincesByCountryIdAsync(id);
        return Json(stateProvinces);
    }

    public async Task<IActionResult> Index()
    {
        return await List();
    }

    public async Task<IActionResult> List()
    {
        if (!(await _permissionService.AuthorizeAsync(EmployeeManagerPermissionProvider.ManageEmployees)))
        {
            return AccessDeniedView();
        }

        EmployeeSearchModel model = await _employeeModelFactory.PrepareEmployeeSearchModel();
        model.IncludeInactive = true;

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> List(EmployeeSearchModel searchModel)
    {
        if (!(await _permissionService.AuthorizeAsync(EmployeeManagerPermissionProvider.ManageEmployees)))
        {
            return AccessDeniedView();
        }

        if (ModelState.IsValid)
        {
            searchModel = await _employeeModelFactory.PrepareEmployeeSearchModel(searchModel);
            var model = await _employeeModelFactory.PrepareEmployeePagedListModel(searchModel);
            return Json(model);
        }
        else
        {
            return NoContent();
        }
    }

    public async Task<IActionResult> Create()
    {
        if (!(await _permissionService.AuthorizeAsync(EmployeeManagerPermissionProvider.ManageEmployees)))
        {
            return AccessDeniedView();
        }

        ViewBag.IsEditView = false;

        var employeeAddressModel = new EmployeeAddressModel();
        employeeAddressModel = await _employeeModelFactory.PrepareEmployeeAddressModel(employeeAddressModel);

        return View(employeeAddressModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeAddressModel employeeAddressModel, [FromQuery(Name = "continue")] bool saveAndContinue = false)
    {
        if (!(await _permissionService.AuthorizeAsync(EmployeeManagerPermissionProvider.ManageEmployees)))
        {
            return AccessDeniedView();
        }

        if (ModelState.IsValid)
        {
            Address address = employeeAddressModel.Address.ToEntity<Address>();
            EmployeeEntity employee = await _employeeModelFactory.PrepareEmployeeEntity(employeeAddressModel.Employee);

            await _addressService.InsertAddressAsync(address);
            await _employeeService.InsertAsync(employee);

            EmployeeAddressMapping employeeAddress = new EmployeeAddressMapping()
            {
                EmployeeId = employee.Id,
                AddressId = address.Id
            };

            await _employeeService.MapEmployeeAddressAsync(employeeAddress);
            _notificationService.SuccessNotification("Employee successfully added...");

            if (saveAndContinue)
            {
                return await Create();
            }
            else
            {
                return RedirectToAction(nameof(List));
            }
        }
        else
        {
            _notificationService.ErrorNotification("Failed to create employee...");
            return BadRequest();
        }
    }

    public async Task<IActionResult> DeleteSelected(int id)
    {
        if (!(await _permissionService.AuthorizeAsync(EmployeeManagerPermissionProvider.ManageEmployees)))
        {
            return AccessDeniedView();
        }

        await _employeeService.DeleteEmployeesAsync(new List<int>() { id });
        _notificationService.SuccessNotification("Employee successfully deleted...");
        return RedirectToAction(nameof(List));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ICollection<int> employeeIds)
    {
        if (!(await _permissionService.AuthorizeAsync(EmployeeManagerPermissionProvider.ManageEmployees)))
        {
            return AccessDeniedView();
        }

        if (employeeIds is null || !employeeIds.Any())
            return NoContent();

        await _employeeService.DeleteEmployeesAsync(employeeIds);
        return RedirectToAction(nameof(List));
    }

    public async Task<IActionResult> Edit(int id)
    {
        if (!(await _permissionService.AuthorizeAsync(EmployeeManagerPermissionProvider.ManageEmployees)))
        {
            return AccessDeniedView();
        }

        ViewBag.IsEditView = true;

        var model = new EmployeeAddressModel();
        model = await _employeeModelFactory.PrepareEmployeeAddressModel(model, id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EmployeeAddressModel employeeAddressModel, [FromQuery(Name = "continue")] bool saveAndContinue = false)
    {
        if (!(await _permissionService.AuthorizeAsync(EmployeeManagerPermissionProvider.ManageEmployees)))
        {
            return AccessDeniedView();
        }

        if (ModelState.IsValid)
        {
            var employee = employeeAddressModel.Employee.ToEntity<EmployeeEntity>();
            var address = employeeAddressModel.Address.ToEntity<Address>();

            await _employeeService.UpdateEmployeeAsync(employee);
            await _addressService.UpdateAddressAsync(address);
            _notificationService.SuccessNotification("Employee successfully updated...");

            if (saveAndContinue)
            {
                return RedirectToAction(nameof(Edit), new { id = employee.Id });
            }
            else
            {
                return RedirectToAction(nameof(List));
            }
        }
        else
        {
            _notificationService.SuccessNotification("Failed to update employee...");
            return BadRequest();
        }
    }
}
