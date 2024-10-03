//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Routing;
//using Nop.Web.Framework;
//using Nop.Web.Framework.Mvc.Routing;

//namespace Nop.Plugin.Misc.EmployeeManager.Infrastructure;
//public class RouteProvider : IRouteProvider
//{
//    public int Priority => -10;

//    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
//    {
//        endpointRouteBuilder.MapControllerRoute("Plugin.EmployeeManager.List",
//            "Admin/EmployeeManager/List",
//            new { area = AreaNames.ADMIN, controller = "EmployeeManagerAdmin", action = "List" });

//        endpointRouteBuilder.MapControllerRoute("Plugin.EmployeeManager.Edit",
//            "Admin/EmployeeManager/EditEmployee/{employeeId:int}",
//            new { area = AreaNames.ADMIN, controller = "EmployeeManagerAdmin", action = "EditEmployee" });

//        endpointRouteBuilder.MapControllerRoute("Plugin.EmployeeManager.Create",
//            "Admin/EmployeeManager/Create",
//            new { area = AreaNames.ADMIN, controller = "EmployeeManagerAdmin", action = "Create" });

//        endpointRouteBuilder.MapControllerRoute("Plugin.EmployeeManager.Delete",
//            "Admin/EmployeeManager/Delete",
//            new { area = AreaNames.ADMIN, controller = "EmployeeManagerAdmin", action = "Delete" });

//        endpointRouteBuilder.MapControllerRoute("Plugin.EmployeeManager.DeleteSelected",
//            "Admin/EmployeeManager/Delete/{employeeId:int}",
//            new { area = AreaNames.ADMIN, controller = "EmployeeManagerAdmin", action = "DeleteSelected" });

//        endpointRouteBuilder.MapControllerRoute("Plugin.EmployeeManager.StatesByCountry",
//            "Admin/EmployeeManager/GetStates/{countryId:int}",
//            new { area = AreaNames.ADMIN, controller = "EmployeeManagerAdmin", action = "GetStates" });
//    }
//}
