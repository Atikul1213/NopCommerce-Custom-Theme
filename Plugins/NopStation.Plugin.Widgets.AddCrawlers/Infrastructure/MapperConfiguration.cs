using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using NopStation.Plugin.Widgets.AddCrawlers.Domains;
using NopStation.Plugin.Widgets.AddCrawlers.Models;

namespace NopStation.Plugin.Widgets.AddCrawlers.Infrastructure;
public class MapperConfiguration : Profile, IOrderedMapperProfile
{
    public int Order => 1;

    public MapperConfiguration()
    {
        CreateMap<Crawler, CrawlerModel>().ReverseMap();
    }
}
