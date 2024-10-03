using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.EmployeeManager.Domain;

namespace Nop.Plugin.Misc.EmployeeManager.Mapping.Builders;
public class EmployeeEntityBuilder : NopEntityBuilder<EmployeeEntity>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(EmployeeEntity.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(EmployeeEntity.Firstname)).AsString(256)
            .WithColumn(nameof(EmployeeEntity.Lastname)).AsString(128)
            .WithColumn(nameof(EmployeeEntity.Phonenumber)).AsFixedLengthString(14)
            .WithColumn(nameof(EmployeeEntity.EmployeeType)).AsInt32()
            .WithColumn(nameof(EmployeeEntity.IsActive)).AsBoolean();
    }
}
