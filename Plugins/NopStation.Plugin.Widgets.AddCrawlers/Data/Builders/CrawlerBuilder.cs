using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using NopStation.Plugin.Widgets.AddCrawlers.Domain;

namespace NopStation.Plugin.Widgets.AddCrawlers.Data.Builders
{
    public class AddCrawlerBuilder : NopEntityBuilder<Crawler>
    {
        #region Methods

        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //table
            //    .WithColumn(nameof(Crawler.CustomerId)).AsInt32().ForeignKey<Customer>();
        }

        #endregion
    }
}
