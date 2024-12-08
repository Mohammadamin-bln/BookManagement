using AutoMapper;
using BookManagement.Application.Features.Commands.users;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Domain.Enitiy;
using BookManagement.Domain.Enum;
using BookManagement.Infrastructure.Repository.Interfaces;

namespace BookManagement.Application.Services.Implements;

public class UserService(IUserRepository repository,IMapper mapper) : IUserService
{
    private readonly IUserRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<Users> AddUser(SingupCommand request)
    {
        try
        {
            var model = _mapper.Map<Users>(request);
            model.MemberShipType = Enums.MemberShipType.Normal;
            var added_user = await _repository.AddUser(model);
            return added_user;
        }
        catch (Exception e)
        {
            //TODO: Exception Handling
            throw e;
        }
    }

    public async Task<Users> Login(string username, string password)
    {
        Users? loginResult = null;
        try
        {
            loginResult = await _repository.Login(username, password);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return loginResult;
    }
    public async Task<Users?> GetUserByName(string username)
    {
        return await _repository.GetUserByName(username);
    }

    public async Task<bool> UpdateUser(Users user)
    {
        return await _repository.UpdateUser(user);
    }
    public async Task<bool> UpgradeMembershipAsync(string username, int month)
    {
        var user = await GetUserByName(username);
        
        if (user == null)
            throw new Exception("User not found");

        if (month == 1)
        {
            if (user.Wallet >= 50)
            {
                user.Wallet -= 50;
                user.MemberShipType = Enums.MemberShipType.Vip;
                user.MemberShipExpire = DateTime.UtcNow.AddDays(30);
                return await _repository.UpdateUser(user);
            }
            return false; 
        }

        if (month == 2)
        {
            if (user.Wallet >= 100)
            {
                user.Wallet -= 100;
                user.MemberShipType = Enums.MemberShipType.Vip;
                user.MemberShipExpire = DateTime.UtcNow.AddDays(60);
                return await _repository.UpdateUser(user);
            }
            return false; 
        }

        throw new ArgumentException("Invalid membership duration. Only 1 or 2 months are allowed.");
    }

}