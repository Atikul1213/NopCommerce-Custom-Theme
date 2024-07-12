using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model.Settings;

namespace Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Factories;
public partial interface ISettingModelFactory
{

    Task<EmployeeSettingModel> PrepareEmployeeSettingModelAsync(EmployeeSettingModel model = null);

}
