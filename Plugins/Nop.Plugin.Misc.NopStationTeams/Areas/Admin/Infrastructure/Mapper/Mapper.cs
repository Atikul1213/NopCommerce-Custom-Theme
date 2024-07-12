using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model.Settings;
using Nop.Plugin.Misc.NopStationTeams.Domain;

namespace Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Infrastructure.Mapper;
public partial class Mapper : Profile, IOrderedMapperProfile
{

    public Mapper()
    {
        CreateEmployeeMaps();
    }


    protected virtual void CreateEmployeeMaps()
    {
        
       CreateMap<EmployeeSettings, EmployeeSettingModel>()

        .ForMember(model => model.IsEditAllow_OverrideForEmployee, options => options.Ignore())
        .ForMember(model => model.IsCertified_OverrideForEmployee, options => options.Ignore())
        .ForMember(model => model.IsMVP_OverrideForEmployee, options => options.Ignore())
        .ForMember(model => model.IsDeleteAllow_OverrideForEmployee, options => options.Ignore())
        .ForMember(model => model.AttachPdfInvoiceToAllEmployee_OverrideForEmployee, options => options.Ignore())
        .ForMember(model => model.AttachPdfInvoiceToCertifiedEmployee_OverrideForEmployee, options => options.Ignore())
        .ForMember(model => model.AttachPdfInvoiceToIsMVPEmployee_OverrideForEmployee, options => options.Ignore())
        .ForMember(model => model.AttachPdfInvoiceToCertifiedAndMVPEmployee_OverrideForEmployee, options => options.Ignore())
        .ForMember(model => model.ActiveStoreScopeConfiguration, options => options.Ignore());


        // map.ReverseMap();

        CreateMap<EmployeeSettingModel, EmployeeSettings>();

    }
    public int Order => 0;
}
