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
        Task<Books> AddBook(Books book);
    }
}
