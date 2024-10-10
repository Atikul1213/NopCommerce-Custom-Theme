using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using NopStation.Plugin.Widgets.AddCrawlers.Domain;
using NopStation.Plugin.Widgets.AddCrawlers.Models;

namespace NopStation.Plugin.Widgets.AddCrawlers.Infrastructure
{
    public class MapperConfiguration : Profile, IOrderedMapperProfile
    {
        public MapperConfiguration()
        {
            CreateMap<Crawler, CrawlerModel>().ReverseMap();
        }

        public int Order => 1;
    }
}