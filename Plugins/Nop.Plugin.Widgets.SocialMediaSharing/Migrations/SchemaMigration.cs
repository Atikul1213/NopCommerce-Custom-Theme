﻿using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Migrations;
[NopSchemaMigration("2024/08/01 06:46:55:1687541", "ShareMedia base schema", MigrationProcessType.Update)]
public class SchemaMigration: ForwardOnlyMigration
{

    public override void Up()
    {
        Create.TableFor<ShareMedia>();

    }
}
