using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookManagement.Application.Features.Commands.books;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Application.Services.Interfaces
{
    public interface IBookService
    {
        public Task<Books> AddBook(AddBookCommand request);
        public Task<List<Books>> GetAllBooks();

        public Task<bool> SaveResevation(string username, int bookId, int days);

        public Task<Books> SearchBook(string bookName); 
        public Task<List<Books>> FilterBookByPrice(int minPrice, int maxPrice);

        public Task<List<Books>> SortBookByName();

        
    } 
}
