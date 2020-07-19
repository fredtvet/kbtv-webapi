using AutoMapper;
using BjBygg.Application.Application.Common.Dto;
using BjBygg.Application.Application.Common.Interfaces;
using BjBygg.Application.Common.BaseEntityCommands.Update;
using CleanArchitecture.Core.Entities;

namespace BjBygg.Application.Application.Commands.DocumentTypeCommands.Update
{
    public class UpdateDocumentTypeCommand : UpdateCommand<DocumentTypeDto>
    {
        public string Name { get; set; }
    }
    public class UpdateDocumentTypeCommandHandler : UpdateCommandHandler<DocumentType, UpdateDocumentTypeCommand, DocumentTypeDto>
    {
        public UpdateDocumentTypeCommandHandler(IAppDbContext dbContext, IMapper mapper) :
            base(dbContext, mapper)
        { }
    }
}