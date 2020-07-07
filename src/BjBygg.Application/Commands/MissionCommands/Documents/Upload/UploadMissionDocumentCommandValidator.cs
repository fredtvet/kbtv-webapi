﻿using FluentValidation;

namespace BjBygg.Application.Commands.MissionCommands.Documents.Upload
{
    public class UploadMissionDocumentCommandValidator : AbstractValidator<UploadMissionDocumentCommand>
    {
        public UploadMissionDocumentCommandValidator()
        {
            RuleFor(v => v.DocumentType)
               .NotEmpty();

            RuleFor(v => v.File)
                .NotEmpty();

            RuleFor(v => v.MissionId)
                .NotEmpty();
        }
    }
}
