using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Mapping.Builders;
public class ShareOptionRecordBuilder : NopEntityBuilder<ShareOption>
{

    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(ShareOption.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(ShareOption.ShareMediaId)).AsInt32()
            .WithColumn(nameof(ShareOption.IncludedLink)).AsBoolean().Nullable()
            .WithColumn(nameof(ShareOption.CustomMessage)).AsString(330).Nullable()
            .WithColumn(nameof(ShareOption.zone)).AsString(343).NotNullable();
    }
}
