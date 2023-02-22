using MediatR;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Commands
{
    public record LoginUserCommand(UserDTO user) : IRequest<UserDTO>
    {
    }
}
