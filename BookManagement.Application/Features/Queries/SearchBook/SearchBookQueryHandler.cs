using BookManagement.Application.Services.Implements;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Domain.Enitiy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Features.Queries.SearchBook
{
    public class SearchBookQueryHandler : IRequestHandler<SearchBookQuery,Books>
    {
        private readonly IBookService _bookService;
        public SearchBookQueryHandler(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }
        public async Task<Books> Handle(SearchBookQuery query , CancellationToken cancellationToken)
        {
            return await _bookService.SearchBook(query.BookName);
        }

    }
}
