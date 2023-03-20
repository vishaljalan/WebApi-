using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1_feb16.Commands;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("LoginUser")]

        public async Task<ActionResult> LoginUser(UserDTO user)
        {
            var user1 = await mediator.Send(new LoginUserCommand(user));
            return Ok(user1);
        }
    }
}
