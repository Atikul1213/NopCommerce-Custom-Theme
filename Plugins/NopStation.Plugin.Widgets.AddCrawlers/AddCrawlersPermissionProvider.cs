using System.Collections.Generic;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using Nop.Services.Security;

namespace NopStation.Plugin.Widgets.AddCrawlers
{
    public class AddCrawlersPermissionProvider : IPermissionProvider
    {
        public static readonly PermissionRecord ManageAddCrawlers = new PermissionRecord { Name = "NopStation Add Crawlers. Manage Crawlers list", SystemName = "ManageNopStationAddCrawlers", Category = "NopStation" };

        public virtual IEnumerable<PermissionRecord> GetPermissions()
        {
            return new[]
            {
                ManageAddCrawlers,
            };
        }

        HashSet<(string systemRoleName, PermissionRecord[] permissions)> IPermissionProvider.GetDefaultPermissions()
        {
            return new HashSet<(string, PermissionRecord[])>
            {
                (
                    NopCustomerDefaults.AdministratorsRoleName,
                    new[]
                    {
                        ManageAddCrawlers,
                    }
                )
            };
        }
    }
}
