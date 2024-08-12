using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.NopQuickTabs.Areas.Admin.Controller;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class TabController : BasePluginController
{

    public TabController()
    {

    }
}
