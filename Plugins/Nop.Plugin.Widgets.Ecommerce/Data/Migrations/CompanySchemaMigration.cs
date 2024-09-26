using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Mapping;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.Ecommerce.Domains;

namespace Nop.Plugin.Widgets.Ecommerce.Data.Migrations;

[NopSchemaMigration("2024/09/21 09:36:55:1687541", "CreateCompanySchemaMigration", MigrationProcessType.Update)]
public class CompanySchemaMigration : AutoReversingMigration
{
    public override void Up()
    {
        if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(Company))).Exists())
        {
            Create.TableFor<Company>();
        }
    }
}
