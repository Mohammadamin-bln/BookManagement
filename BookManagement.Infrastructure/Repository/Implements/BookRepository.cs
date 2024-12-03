using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Context;
using BookManagement.Infrastructure.Repository.Interfaces;

namespace BookManagement.Infrastructure.Repository.Implements
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Books> AddBook(Books book)
        {
            var addedBooks= _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return addedBooks.Entity;
        }

    }
}
