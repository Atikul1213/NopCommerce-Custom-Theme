using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Migrations;
[NopSchemaMigration("2024/08/31 09:36:55:1687541", "CreateCompanyMigration", MigrationProcessType.Update)]
public class SchemaMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.TableFor<Company>();

    }
}
