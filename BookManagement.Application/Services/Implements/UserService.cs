using AutoMapper;
using BookManagement.Application.Features.Command;
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
            model.MemberShipType = Enums.MemberShipType.Admin;
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
}