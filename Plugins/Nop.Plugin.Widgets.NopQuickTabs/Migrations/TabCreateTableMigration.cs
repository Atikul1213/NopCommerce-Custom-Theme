using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;

namespace Nop.Plugin.Widgets.NopQuickTabs.Migrations;
[NopSchemaMigration("2024/08/12 11:21:55:1687541", "TabTableCreateMigration", MigrationProcessType.Update)]
public class TabCreateTableMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.TableFor<Tab>();

    }

}
