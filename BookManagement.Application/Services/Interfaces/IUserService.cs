using BookManagement.Application.Features.Commands.users;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Application.Services.Interfaces;

public interface IUserService
{
    //TODO: Create DTO For added user
    public Task<Users> AddUser(SingupCommand request);
    
    //TODO: Create Dto for login response
    public Task<Users> Login(string username, string password);
    public Task<Users?> GetUserById(string username);

    public Task<bool> UpdateUser(Users user);
}