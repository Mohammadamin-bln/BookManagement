using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.Services.Implements;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Domain.Enitiy;
using MediatR;

namespace BookManagement.Application.Features.Queries.FilterBook
{
    public class FilterBookByPriceQueryHandler : IRequestHandler<FilterBookByPriceQuery,List<Books>>
    {
        private readonly IBookService _bookService;
        public FilterBookByPriceQueryHandler(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));


        }

        public async Task<List<Books>> Handle(FilterBookByPriceQuery request,CancellationToken cancellationToken)
        {
            return await _bookService.FilterBookByPrice(request.MinPrice, request.MaxPrice); 
        }
    }
}
