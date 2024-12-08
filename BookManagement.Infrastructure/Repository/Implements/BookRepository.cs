using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Context;
using BookManagement.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

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
            var addedBooks = _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return addedBooks.Entity;
        }
        public async Task<List<Books>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public Task<Books?> GetBookById(int id)
        {
            return _context.Books.FirstOrDefaultAsync(a => a.Id == id);


        }
        public Task<Books?> GetBookByName(string name)
        {
            return _context.Books.FirstOrDefaultAsync(b => b.Name == name);
        }

        public Task<List<Books>> FilterBookByPrice(int minPrice, int maxPrice)
        {
            return _context.Books
                .Where(book => book.Price >= minPrice && book.Price <= maxPrice)
                .ToListAsync();
        }

        public Task<List<Books>> SortBookByName()
        {
            return _context.Books.OrderBy(book => book.Name).ToListAsync();
        }

        public Task<List<Books>> SortBookByPrice()
        {
            return _context.Books.OrderBy(book => book.Price).ToListAsync();
        }
    }
}
