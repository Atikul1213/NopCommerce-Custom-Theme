using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Misc.EmployeeManager.Domain;
using Nop.Plugin.Misc.EmployeeManager.Models;

namespace Nop.Plugin.Misc.EmployeeManager.Infrastructure.Mapper;
public class MapperConfiguration : Profile, IOrderedMapperProfile
{
    public MapperConfiguration()
    {
        CreateMap<EmployeeEntity, EmployeeModel>();
        CreateMap<EmployeeModel, EmployeeEntity>();
    }

    public int Order => 1;
}
