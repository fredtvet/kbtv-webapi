using BjBygg.Application.Shared;
using BjBygg.Application.Shared.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BjBygg.Application.Commands.InboundEmailPasswordCommands.Create
{
    public class CreateInboundEmailPasswordCommand : IRequest<InboundEmailPasswordDto>
    {
        [Required(ErrorMessage = "{0} må fylles ut.")]
        [Display(Name = "Passord")]
        [StringLength(50, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        public string Password { get; set; }
    }
}