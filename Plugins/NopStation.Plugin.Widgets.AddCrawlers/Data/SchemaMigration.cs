using FluentMigrator;
using Nop.Core;
using Nop.Data.Extensions;
using Nop.Data.Mapping;
using Nop.Data.Migrations;
using NopStation.Plugin.Widgets.AddCrawlers.Domain;

namespace NopStation.Plugin.Widgets.AddCrawlers.Data
{
    [NopSchemaMigration("2023/12/12 00:00:00", "NopStation.Plugin.Widgets.AddCrawlers base schema", MigrationProcessType.Update)]
    public class SchemaMigration : AutoReversingMigration
    {

        public static string TableName<T>() where T : BaseEntity
        {
            return NameCompatibilityManager.GetTableName(typeof(T));
        }

        public override void Up()
        {
            if (!Schema.Table(TableName<Crawler>()).Exists())
                Create.TableFor<Crawler>();
        }
    }
}