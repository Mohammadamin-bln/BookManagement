using BookManagement.Domain.Enitiy;

namespace BookManagement.Infrastructure.Repository.Interfaces;

public interface IUserRepository
{
    public Task<Users> AddUser(Users user);
    public Task<Users?> Login(string username, string password);
}