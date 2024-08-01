using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Mapping.Builders;
public class ShareMediaRecordBuilder : NopEntityBuilder<ShareMedia>
{

    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(ShareMedia.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(ShareMedia.Name)).AsString(400).NotNullable()
            .WithColumn(nameof(ShareMedia.IconId)).AsInt32()
            .WithColumn(nameof(ShareMedia.DisplayOrder)).AsInt32().Nullable()
            .WithColumn(nameof(ShareMedia.Url)).AsString(400).NotNullable()
            .WithColumn(nameof(ShareMedia.IsActive)).AsBoolean();

    }


}
