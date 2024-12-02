using BookManagement.Application.Features.Command;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Application.Services.Interfaces;

public interface IUserService
{
    //TODO: Create DTO For added user
    public Task<Users> AddUser(SingupCommand request);
    
    //TODO: Create Dto for login response
    public Task<Users> Login(string username, string password);
}