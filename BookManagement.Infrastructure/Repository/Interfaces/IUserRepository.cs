using BookManagement.Domain.Enitiy;

namespace BookManagement.Infrastructure.Repository.Interfaces;

public interface IUserRepository
{
    public Task<Users> AddUser(Users user);
    public Task<Users?> Login(string username, string password);

    public Task<Users?> GetUserById(string username);

    public Task<bool> UpdateUser(Users user);
}