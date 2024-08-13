using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Factories;
using Nop.Plugin.Widgets.NopQuickTabs.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Controller;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class TabController : BasePluginController
{
    private readonly ITabService _tabService;
    private readonly ITabFactories _tabFactories;
    public TabController(ITabService tabService, ITabFactories tabFactories)
    {
        _tabService = tabService;
        _tabFactories = tabFactories;
    }





}
