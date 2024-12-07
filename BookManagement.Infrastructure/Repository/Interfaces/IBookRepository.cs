using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Infrastructure.Repository.Interfaces
{
    public interface IBookRepository
    {
        public Task<Books> AddBook(Books book);
        public Task<List<Books>> GetAllBooks();

        public Task<Books?> GetBookById(int id);

        public Task<Books?> GetBookByName(string bookName);
    }
}
