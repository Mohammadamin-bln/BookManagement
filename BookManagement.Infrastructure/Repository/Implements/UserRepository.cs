using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using BookManagement.Infrastructure.Repository.Interfaces;

namespace BookManagement.Infrastructure.Repository.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Users> AddUser(Users user)
        {
            var addedUser = _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return addedUser.Entity;
        }

        public async Task<Users?> Login(string username, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<Users?> GetUserById(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username==username);
        }

        public async Task<bool> UpdateUser(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }
    }
}
