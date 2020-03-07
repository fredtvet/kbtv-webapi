using AutoMapper;
using BjBygg.Application.Shared;
using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BjBygg.Application.Shared
{
    public class MissionNoteDtoProfile : Profile
    {
        public MissionNoteDtoProfile()
        {
            CreateMap<MissionNote, MissionNoteDto>();
            CreateMap<MissionNoteDto, MissionNote>();
        }
    }
}