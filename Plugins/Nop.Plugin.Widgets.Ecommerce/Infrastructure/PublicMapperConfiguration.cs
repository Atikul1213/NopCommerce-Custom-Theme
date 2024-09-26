using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Widgets.Ecommerce.Domains;
using Nop.Plugin.Widgets.Ecommerce.Models.ProductBrochure;

namespace Nop.Plugin.Widgets.Ecommerce.Infrastructure;
public class PublicMapperConfiguration : Profile, IOrderedMapperProfile
{
    public int Order => 1;

    public PublicMapperConfiguration()
    {
        CreateMap<ProductBrochure, ProductBrochureInfoModel>().ReverseMap();
    }
}
