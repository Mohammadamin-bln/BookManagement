using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookManagement.Application.Features.Commands.books;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Repository.Interfaces;

namespace BookManagement.Application.Services.Implements
{
    public class BookService(IBookRepository repository, IMapper mapper) : IBookService
    {
        private readonly IBookRepository _bookRepository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Books> AddBook(AddBookCommand request)
            
        {
            try
            {
                var model = _mapper.Map<Books>(request);
                var addedBook = await _bookRepository.AddBook(model);
                return addedBook;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
