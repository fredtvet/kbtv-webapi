using BjBygg.Application.Shared;
using CleanArchitecture.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BjBygg.Application.Commands.MissionCommands.Documents.Upload
{
    public class UploadMissionDocumentCommand : IRequest<MissionDocumentDto>
    {
        [Required]
        public BasicFileStream File { get; set; }

        [Required]
        public int MissionId { get; set; }

        [Required]
        public DocumentTypeDto DocumentType { get; set; }

    }
}
