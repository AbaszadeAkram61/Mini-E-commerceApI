using E_TicaretApI.Application.Features.Commands.Users.CreateUser;
using E_TicaretApI.Application.Features.Commands.Users.GoogleLogin;
using E_TicaretApI.Application.Features.Commands.Users.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_TicaretApI.ApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response=await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("action")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response=await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest request)
        {
            GoogleLoginCommandResponse response=await  _mediator.Send(request);
            return Ok(response);
        }
    }
}
