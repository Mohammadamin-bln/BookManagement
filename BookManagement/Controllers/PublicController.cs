using BookManagement.Application.Features.Commands;
using BookManagement.Application.Features.Commands.users;
using BookManagement.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SingupCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(new { UserId = userId });
        }

        [HttpPost("Signin")]
        public async Task<IActionResult> Login(SingInQuery query)
        {
            var token = await _mediator.Send(query);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token = token });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only-endpoint")]
        public IActionResult GetAdminData()
        {
            return Ok("This is admin-only data.");
        }

    }
}
