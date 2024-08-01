using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Migrations;
[NopSchemaMigration("2024/08/01 01:08:55:1687541", "ShareOption base schema", MigrationProcessType.Update)]
public class ShareOptionMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.TableFor<ShareOption>();
    }
}
