using AutoMapper;
using Nop.Core.Infrastructure.Mapper;

namespace Nop.Plugin.Widgets.Ecommerce.Infrastructure;
public class PublicMapperConfiguration : Profile, IOrderedMapperProfile
{
    public int Order => 1;

    public PublicMapperConfiguration()
    {

    }
}
