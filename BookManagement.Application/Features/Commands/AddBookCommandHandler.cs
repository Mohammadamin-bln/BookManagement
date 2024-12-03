using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Domain.Enitiy;
using MediatR;

namespace BookManagement.Application.Features.Commands
{
    public class AddBookCommandHandler(IBookService bookService) : IRequestHandler<AddBookCommand,bool>
    {
        private readonly IBookService _bookService = bookService;

        public async Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            Books book = await _bookService.AddBook(request);
            return true;
            
        }


    }
}
