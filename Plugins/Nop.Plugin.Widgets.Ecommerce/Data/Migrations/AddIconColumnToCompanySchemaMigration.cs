using FluentMigrator;
using Nop.Data.Mapping;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.Ecommerce.Domains;
namespace Nop.Plugin.Widgets.Ecommerce.Data.Migrations
{
    [NopMigration("2024/09/26 09:11:00:0000000", "Company Add Display Order Column To Company Schema Migration", MigrationProcessType.Update)]
    public class AddIconColumnToCompanySchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            if (Schema.Table(NameCompatibilityManager.GetTableName(typeof(Company))).Exists() &&
                !Schema.Table(NameCompatibilityManager.GetTableName(typeof(Company))).Column(nameof(Company.DisplayOrder)).Exists())
            {
                // Add 'IconPictureId' column to the table
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(Company)))
                    .AddColumn(nameof(Company.DisplayOrder)).AsInt32().Nullable();
            }

        }
    }
}
