using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Data.Builders;
public class ProductBrochureEntityBuilder : NopEntityBuilder<ProductBrochure>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(ProductBrochure.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(ProductBrochure.ButtonText)).AsString(256)
            .WithColumn(nameof(ProductBrochure.ProductId)).AsInt32()
            .WithColumn(nameof(ProductBrochure.ProductDownloadId)).AsInt32()
            .WithColumn(nameof(ProductBrochure.DisplayOrder)).AsInt32()
            .WithColumn(nameof(ProductBrochure.IsActive)).AsBoolean();
    }
}
