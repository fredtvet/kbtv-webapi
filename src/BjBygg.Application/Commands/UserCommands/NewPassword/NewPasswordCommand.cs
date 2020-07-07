using MediatR;

namespace BjBygg.Application.Commands.UserCommands.NewPassword
{
    public class NewPasswordCommand : IRequest
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; }
    }
}
