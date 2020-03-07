﻿using AutoMapper;
using CleanArchitecture.Core.Entities;

namespace BjBygg.Application.Shared
{ 
    public class MissionDtoProfile : Profile
    {
        public MissionDtoProfile()
        {
            CreateMap<Mission, MissionDto>()
                .ForMember(dest => dest.MissionType, opt => opt.MapFrom(src => src.MissionType))
                .ForMember(dest => dest.Employer, opt => opt.MapFrom(src => src.Employer));

            CreateMap<MissionDto, Mission>()
                .ForMember(dest => dest.MissionType, opt => opt.MapFrom(src => src.MissionType))
                .ForMember(dest => dest.Employer, opt => opt.MapFrom(src => src.Employer));

            CreateMap<MissionTypeDto, MissionType>();
            CreateMap<EmployerDto, Employer>();

            CreateMap<MissionType, MissionTypeDto>();
            CreateMap<Employer, EmployerDto>();
        }
    }
}