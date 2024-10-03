using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.EmployeeManager.Domain;

namespace Nop.Plugin.Misc.EmployeeManager.Mapping.Builders;

public class EmployeeAddressMappingBuilder : NopEntityBuilder<EmployeeAddressMapping>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(EmployeeAddressMapping.EmployeeId)).AsInt32().ForeignKey<EmployeeEntity>(nameof(EmployeeEntity), nameof(EmployeeEntity.Id))
            .WithColumn(nameof(EmployeeAddressMapping.AddressId)).AsInt32().ForeignKey<Address>(nameof(Address), nameof(Address.Id));
    }
}
