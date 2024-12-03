using BookManagement.Application.Features.Commands.books;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(AddBookCommand command)
        {
            var book= await _mediator.Send(command);
            if (!book)
            {
                return BadRequest("invalid data");
            }
            return Ok("book added successfully");
        }

    }
}
