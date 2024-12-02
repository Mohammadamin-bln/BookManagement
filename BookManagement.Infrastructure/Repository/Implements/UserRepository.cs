using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using BookManagement.Infrastructure.Repository.Interfaces;

namespace BookManagement.Infrastructure.Repository.Implements
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<Users> AddUser(Users user)
        {
            
            var addedUser = context.Users.Add(user);
            await context.SaveChangesAsync();
            return addedUser.Entity;
        }

        public async Task<Users?> Login(string username, string password)
        {
            var loginResult = await context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            return loginResult;
        }
    }
}
