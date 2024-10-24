﻿using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Widgets.SocialMediaSharing.Domains;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Infrastructure.Mapper;
public class Mapper : Profile, IOrderedMapperProfile
{
    public int Order => 0;

    public Mapper()
    {
        CreateShareMediaMaps();
    }


    public virtual void CreateShareMediaMaps()
    {
        CreateMap<ShareMedia, ShareMediaModel>()
        .ForMember(model => model.IconThumbnailUrl, option => option.Ignore());

        CreateMap<ShareMediaModel, ShareMedia>();
        
    }
}
