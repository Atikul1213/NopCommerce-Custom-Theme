using FluentMigrator;
using Nop.Core;
using Nop.Data.Extensions;
using Nop.Data.Mapping;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.Ecommerce.Domains;

namespace Nop.Plugin.Widgets.Ecommerce.Data;

[NopSchemaMigration("2024/08/31 09:36:55:1687541", "CreateCompanyMigration", MigrationProcessType.Update)]
public class SchemaMigration : AutoReversingMigration
{
    public static string TableName<T>() where T : BaseEntity
    {
        return NameCompatibilityManager.GetTableName(typeof(T));
    }

    public override void Up()
    {
        if (!Schema.Table(TableName<Company>()).Exists())
            Create.TableFor<Company>();

        if (!Schema.Table(TableName<ProductBrochure>()).Exists())
            Create.TableFor<ProductBrochure>();

    }
}
