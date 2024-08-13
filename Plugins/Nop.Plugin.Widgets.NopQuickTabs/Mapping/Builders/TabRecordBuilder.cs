using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;

namespace Nop.Plugin.Widgets.NopQuickTabs.Mapping.Builders;
public class TabRecordBuilder : NopEntityBuilder<Tab>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(Tab.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(Tab.ProductId)).AsInt32().NotNullable()
            .WithColumn(nameof(Tab.SystemName)).AsString(400)
            .WithColumn(nameof(Tab.DisplayName)).AsString(400).NotNullable()
            .WithColumn(nameof(Tab.Description)).AsString(1000)
            .WithColumn(nameof(Tab.LimitedToStores)).AsBoolean()
            .WithColumn(nameof(Tab.DisplayOrder)).AsInt32()
            .WithColumn(nameof(Tab.IsEnable)).AsBoolean();

    }
}
