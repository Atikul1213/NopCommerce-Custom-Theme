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
            .WithColumn(nameof(Tab.Title)).AsString(400)
            .WithColumn(nameof(Tab.Description)).AsString(1000).Nullable()
            .WithColumn(nameof(Tab.DisplayOrder)).AsInt32()
            .WithColumn(nameof(Tab.IsActive)).AsBoolean()
            .WithColumn(nameof(Tab.ContentType)).AsInt32().NotNullable();

    }
}
