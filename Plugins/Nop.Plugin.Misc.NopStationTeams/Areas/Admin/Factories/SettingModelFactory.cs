using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Nop.Core;
using Nop.Data;
using Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model.Settings;
using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Services;
using Nop.Services.Configuration;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;

namespace Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Factories;
internal class SettingModelFactory : ISettingModelFactory
{
    private readonly IEmployeeService _employeeService;
    private readonly ISettingService _settingService;
    private readonly IStoreContext _storeContext;
    private readonly INopDataProvider _dataProvider;
    public SettingModelFactory(IEmployeeService employeeService, ISettingService settingService, IStoreContext storeContext, INopDataProvider nopDataProvider)
    {
        _employeeService = employeeService;
        _settingService = settingService;
        _storeContext = storeContext;
        _dataProvider = nopDataProvider;

    }
    public virtual async Task<EmployeeSettingModel> PrepareEmployeeSettingModelAsync(EmployeeSettingModel model = null)
    {

        var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
       
        var employeeSettings = await _settingService.LoadSettingAsync<EmployeeSettings>(storeId);

        model ??= employeeSettings.ToSettingsModel<EmployeeSettingModel>();
        // model ??= IMapper.Map<EmployeeSettingModel>(employeeSettings);
        model.ActiveStoreScopeConfiguration = storeId;
        //model.OrderIdent = await _dataProvider.GetTableIdentAsync<EmployeeSettings>();


        model.IsCertified_OverrideForEmployee = await _settingService.SettingExistsAsync(employeeSettings, x => x.IsCertified);
        model.IsDeleteAllow_OverrideForEmployee = await _settingService.SettingExistsAsync(employeeSettings, x => x.IsDeleteAllow);
        model.IsEditAllow_OverrideForEmployee = await _settingService.SettingExistsAsync(employeeSettings, x => x.IsEditAllow);
        model.IsMVP_OverrideForEmployee = await _settingService.SettingExistsAsync(employeeSettings, x=>x.IsMVP);
        model.AttachPdfInvoiceToCertifiedAndMVPEmployee_OverrideForEmployee = await _settingService.SettingExistsAsync(employeeSettings, x => x.AttachPdfInvoiceToCertifiedAndMVPEmployee);
        model.AttachPdfInvoiceToCertifiedEmployee_OverrideForEmployee = await _settingService.SettingExistsAsync(employeeSettings, x => x.AttachPdfInvoiceToCertifiedEmployee);
        model.AttachPdfInvoiceToAllEmployee_OverrideForEmployee = await _settingService.SettingExistsAsync(employeeSettings, x => x.AttachPdfInvoiceToAllEmployee);


        return model;

    }
}
