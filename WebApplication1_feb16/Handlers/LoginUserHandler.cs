using MediatR;
using WebApplication1_feb16.Commands;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Handlers
{

    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserDTO>
    {
        private readonly IAuth auth;

        public LoginUserHandler(IAuth auth)
        {
            this.auth = auth;
        }

        public async Task<UserDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(auth.LoginUser(request.user));
        }
    }
}
