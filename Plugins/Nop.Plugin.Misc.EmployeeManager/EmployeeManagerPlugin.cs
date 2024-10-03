using Microsoft.AspNetCore.Routing;
using Nop.Core.Domain.Security;
using Nop.Plugin.Misc.EmployeeManager.Services.Security;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.EmployeeManager;

public class EmployeeManagerPlugin : BasePlugin, IAdminMenuPlugin
{
    private readonly ILocalizationService _localizationService;
    private readonly IPermissionService _permissionService;

    public EmployeeManagerPlugin(ILocalizationService localizationService, IPermissionService permissionService)
    {
        _localizationService = localizationService;
        _permissionService = permissionService;
    }

    public override async Task InstallAsync()
    {
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            [EmployeeManagerConstants.EMPLOYEE_LIST] = "Employee List - Employee Manager",
            [EmployeeManagerConstants.EMPLOYEE_CREATE_UPDATE_INFO_CARD_TITLE] = "Employee Info - Employee Manager",
            [EmployeeManagerConstants.EMPLOYEE_ADD_NEW] = "Employee Add New - Employee Manager",
            [EmployeeManagerConstants.EMPLOYEE_EDIT_EMPLOYEE] = "Edit Employee - Employee Manager",
            [EmployeeManagerConstants.EMPLOYEE_BACK_TO_LIST] = "Back to employee list",
            [EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_FIRSTNAME] = "First Name",
            [EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_LASTNAME] = "Last Name",
            [EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_PHONENUMBER] = "Phone Number",
            [EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_EMPLOYEE_TYPE] = "Employee Type",
            [EmployeeManagerConstants.EMPLOYEE_MODEL_FIELD_IS_ACTIVE] = "Is Active",
            [EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_FIRSTNAME] = "First Name",
            [EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_LASTNAME] = "Last Name",
            [EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_PHONENUMBER] = "Phone Number",
            [EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_EMPLOYEE_TYPE] = "Employee Type",
            [EmployeeManagerConstants.EMPLOYEE_SEARCH_MODEL_FIELD_INCLUDE_INACTIVE] = "Include Inactive",
        });

        await _permissionService.InstallPermissionsAsync(new EmployeeManagerPermissionProvider());
        await base.InstallAsync();
    }

    public override async Task UninstallAsync()
    {
        await _localizationService.DeleteLocaleResourcesAsync(EmployeeManagerConstants.BASE);

        Type employeeManagerPermissionProviderType = typeof(EmployeeManagerPermissionProvider);
     
        IEnumerable<string> permissionSystemNames = employeeManagerPermissionProviderType.GetFields()
            .Where(field => field.FieldType == typeof(PermissionRecord))
            .Select(field => (field.GetValue(employeeManagerPermissionProviderType) as PermissionRecord)!.SystemName);

        IEnumerable<PermissionRecord> permissionRecords = (await _permissionService.GetAllPermissionRecordsAsync())
            .Where(permission => permissionSystemNames.Contains(permission.SystemName));

        List<PermissionRecordCustomerRoleMapping> customerMappings = await (permissionRecords.SelectManyAwait(
            async permission => await _permissionService.GetMappingByPermissionRecordIdAsync(permission.Id)
        )).ToListAsync();

        foreach (var customerMapping in customerMappings)
        {
            await _permissionService
                .DeletePermissionRecordCustomerRoleMappingAsync(customerMapping.PermissionRecordId,customerMapping.CustomerRoleId);
        }

        foreach (var permission in permissionRecords)
        {
            await _permissionService.DeletePermissionRecordAsync(permission);
        }

        await base.UninstallAsync();
    }

    public Task ManageSiteMapAsync(SiteMapNode rootNode)
    {
        var employeeManagerMenuItem = new SiteMapNode()
        {
            SystemName = "EmployeeManager",
            Title = "Employee Manager",
            ControllerName = "EmployeeManagerAdmin",
            ActionName = "List",
            IconClass = "far fa-dot-circle",
            Visible = true,
            RouteValues = new RouteValueDictionary() { { "area", AreaNames.ADMIN } },
        };

        rootNode.ChildNodes.Add(employeeManagerMenuItem);

        var addEmployeeSubmenuItem = new SiteMapNode()
        {
            SystemName = "EmployeeManager.Create",
            Title = "Add new employee",
            ControllerName = "EmployeeManagerAdmin",
            ActionName = "Create",
            IconClass = "far fa-dot-circle",
            Visible = true,
            RouteValues = new RouteValueDictionary() { { "area", AreaNames.ADMIN } },
        };

        var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "EmployeeManager");
        if (pluginNode != null)
            pluginNode.ChildNodes.Add(addEmployeeSubmenuItem);
        else
            rootNode.ChildNodes.Add(addEmployeeSubmenuItem);

        return Task.CompletedTask;

    }
}
