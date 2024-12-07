using BookManagement.Application.Features.Commands.books;
using BookManagement.Application.Features.Commands.users;
using BookManagement.Application.Features.Commands.Wallet;
using BookManagement.Application.Features.Queries.SearchBook;
using BookManagement.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Presentation.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookService _bookService;

        public UserController(IMediator mediator, IBookService bookService)
        {
            _mediator = mediator;
            _bookService = bookService;
        }
        [Authorize]
        [HttpPost("add/wallet")]
        public async Task<IActionResult> AddWallet([FromForm]AddWalletCommand command)
        {
            var token=  await _mediator.Send(command);
            if(token)
                return Ok("wallet successfully added");
            return BadRequest("failed to add wallet");
        }
        [Authorize]
        [HttpGet("SeeBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
           var books = await _bookService.GetAllBooks();
            if (books.Count==0)
            
                return BadRequest("books are empty");
            return Ok(books);
            
        }
        [Authorize]
        [HttpPost("upgrade/membership")]
        public async Task<IActionResult> UpgradeMemberShipType([FromBody] UpgradeMembershipCommand command)
        {
            var token= await _mediator.Send(command);
            if (token)
                return Ok("successfully upgraded");
            return BadRequest("coult not upgrade membershiptype");

        }

        [Authorize]
        [HttpPost("Reserve/Book")]

        public async Task<IActionResult> ReserveBook(BookReservationCommand request)
        {
            bool result = await _mediator.Send(request);
            if (!result)
            {
                return BadRequest("failed to reserve book");
            }
            return Ok("book reserved successfully");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SearchBook(SearchBookQuery request)
        {
            var result= await _mediator.Send(request);
            if (result == null)
            {
                return BadRequest("book not found");
            }
            return Ok(result);
        }
            


    }
}
