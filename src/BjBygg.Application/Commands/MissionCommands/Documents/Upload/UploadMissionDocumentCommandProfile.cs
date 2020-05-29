﻿using AutoMapper;
using BjBygg.Application.Shared;
using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BjBygg.Application.Commands.MissionCommands.Documents.Upload
{
    class UploadMissionDocumentCommandProfile : Profile
    {
        public UploadMissionDocumentCommandProfile()
        {
            CreateMap<UploadMissionDocumentCommand, MissionDocument>()
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType))
                .ForMember(dest => dest.FileURL, opt => opt.Ignore())
                .ForSourceMember(src => src.File, dest => dest.DoNotValidate());

            CreateMap<MissionDocument, MissionDocumentDto>()
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType));

            CreateMap<DocumentTypeDto, DocumentType>();
            CreateMap<DocumentType, DocumentTypeDto>();
        }
    }
}