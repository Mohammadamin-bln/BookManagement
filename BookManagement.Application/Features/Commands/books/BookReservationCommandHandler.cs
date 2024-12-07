using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.Services.Implements;
using BookManagement.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookManagement.Application.Features.Commands.books
{
    public class BookReservationCommandHandler : IRequestHandler<BookReservationCommand, bool>
    {
        private readonly IBookService _bookService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookReservationCommandHandler(IBookService bookService, IHttpContextAccessor httpContextAccessor)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        }

        public async Task<bool> Handle(BookReservationCommand request, CancellationToken cancellationToken)
        {
            var username = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(username))
                throw new UnauthorizedAccessException("User is not logged in.");

            return await _bookService.SaveResevation(username, request.BookId, request.Days);
        }
    }
}
