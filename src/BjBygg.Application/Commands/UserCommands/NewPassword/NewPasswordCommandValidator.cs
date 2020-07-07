﻿using FluentValidation;

namespace BjBygg.Application.Commands.UserCommands.NewPassword
{
    public class NewPasswordCommandValidator : AbstractValidator<NewPasswordCommand>
    {
        public NewPasswordCommandValidator()
        {
            RuleFor(v => v.NewPassword)
                .NotEmpty();

            RuleFor(v => v.UserName)
                .NotEmpty();
        }
    }
}
