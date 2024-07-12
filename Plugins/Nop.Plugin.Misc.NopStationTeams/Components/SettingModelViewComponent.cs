using Microsoft.AspNetCore.Mvc;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Misc.NopStationTeams.Components;
public partial class SettingModelViewComponent : NopViewComponent
{
    protected readonly ISettingModelFactory _settingModelFactory;

    #region Ctor
    public SettingModelViewComponent(ISettingModelFactory settingModelFactory)
    {
        _settingModelFactory = settingModelFactory;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync(string modelName = "settings-advanced-mode")
    {
        var model = await _settingModelFactory.PrepareSettingModeModelAsync(modelName);
        return View(model);
    }



}
