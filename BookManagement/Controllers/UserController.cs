using BookManagement.Application.Features.Commands.Wallet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost("add/wallet")]
        public async Task<IActionResult> AddWallet([FromForm]AddWalletCommand command)
        {
            var token= _mediator.Send(command);
            return Ok("wallet successfully added");
        }

    }
}
