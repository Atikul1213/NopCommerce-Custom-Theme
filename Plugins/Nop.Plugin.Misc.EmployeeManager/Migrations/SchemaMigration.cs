using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Core.Domain.Common;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.EmployeeManager.Domain;

namespace Nop.Plugin.Misc.EmployeeManager.Migrations;

[NopMigration("2025/03/01 14:48:00:0000000", "Mics.EmployeeManager.Employee base schema with identity", MigrationProcessType.NoMatter)]
public class SchemaMigration : AutoReversingMigration
{
    public override void Up()
    {
        Create.TableFor<EmployeeEntity>();
        Create.TableFor<EmployeeAddressMapping>();
    }
}
