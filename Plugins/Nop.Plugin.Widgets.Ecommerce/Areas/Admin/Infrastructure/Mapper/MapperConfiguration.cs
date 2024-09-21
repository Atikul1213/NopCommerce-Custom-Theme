using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Infrastructure.Mapper;
public class MapperConfiguration : Profile, IOrderedMapperProfile
{
    public int Order => 1;

    public MapperConfiguration()
    {
        CreateMap<Company, CompanyModel>().ReverseMap();
    }

}
