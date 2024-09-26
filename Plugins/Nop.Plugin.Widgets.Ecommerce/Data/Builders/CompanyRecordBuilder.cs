using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Widgets.Ecommerce.Domains;

namespace Nop.Plugin.Widgets.Ecommerce.Data.Builders;
public class CompanyRecordBuilder : NopEntityBuilder<Company>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(Company.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(Company.Name)).AsString(400)
            .WithColumn(nameof(Company.DisplayOrder)).AsInt32()
            .WithColumn(nameof(Company.CompanyType)).AsInt32()
            .WithColumn(nameof(Company.IsActive)).AsBoolean()
            .WithColumn(nameof(Company.PictureId)).AsInt32();

    }
}
