using FluentMigrator;
using Nop.Core;
using Nop.Data.Extensions;
using Nop.Data.Mapping;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Data.Migrations;
[NopSchemaMigration("2024/09/12 10:47:55:1687541", "ProductBrochure create table schema migration", MigrationProcessType.Update)]
public class ProductBrochureSchemaMigration : ForwardOnlyMigration
{
    public static string TableName<T>() where T : BaseEntity
    {
        return NameCompatibilityManager.GetTableName(typeof(T));
    }
    public override void Up()
    {
        if (!Schema.Table(TableName<ProductBrochure>()).Exists())
            Create.TableFor<ProductBrochure>();
    }

}
