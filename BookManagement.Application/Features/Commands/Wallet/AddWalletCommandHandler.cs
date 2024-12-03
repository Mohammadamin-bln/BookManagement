using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookManagement.Application.Features.Commands.Wallet
{
    public class AddWalletCommandHandler(IUserService userService, IHttpContextAccessor httpContextAccessor) : IRequestHandler<AddWalletCommand,bool>
    {
        private readonly IUserService _userService=userService;
        private readonly IHttpContextAccessor _contextAccessor = httpContextAccessor;

        public  async Task<bool> Handle(AddWalletCommand request,CancellationToken cancellationToken)
        {
            var username= _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(username))
                throw new UnauthorizedAccessException("not authorized");

            var user = await _userService.GetUserById(username);
            if (user == null)
                throw new Exception("User not found");
            user.Wallet = request.Amount;
            _userService.UpdateUser(user);
            return true;



        }
    }
}
