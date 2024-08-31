using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model;
using Nop.Plugin.Widgets.Ecommerce.Domain;

namespace Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Infrastructure.Mapper;
public class Mapper : Profile, IOrderedMapperProfile
{
    public int Order => 0;

    public Mapper()
    {
        CreateConfigMaps();
    }


    protected virtual void CreateConfigMaps()
    {
        CreateMap<CompanyModel, Company>();




        CreateMap<Company, CompanyModel>();
    }

}
