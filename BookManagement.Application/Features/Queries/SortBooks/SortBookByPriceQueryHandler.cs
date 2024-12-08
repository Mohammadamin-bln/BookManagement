using BookManagement.Application.Services.Interfaces;
using BookManagement.Domain.Enitiy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Features.Queries.SortBooks
{
    public class SortBookByPriceQueryHandler : IRequestHandler<SortBookByPriceQuery,List<Books>>
    {
        private readonly IBookService _bookService;

        public SortBookByPriceQueryHandler(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));

        }
        public async Task<List<Books>> Handle(SortBookByPriceQuery request, CancellationToken cancellationToken)
        {
            return await _bookService.SortBookByPrice();
        }


    }
}
