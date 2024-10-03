using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.CompanyModel;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure;
using Nop.Plugin.Widgets.Ecommerce.Domains;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Infrastructure.Mapper;
public class MapperConfiguration : Profile, IOrderedMapperProfile
{
    public int Order => 1;

    public MapperConfiguration()
    {
        CreateMap<Company, CompanyModel>().ReverseMap();
        CreateMap<ProductBrochure, ProductBrochureModel>().ReverseMap();
    }

}
