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
    public class AddWalletCommandHandler : IRequestHandler<AddWalletCommand,bool>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AddWalletCommandHandler(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }
        public  async Task<bool> Handle(AddWalletCommand request,CancellationToken cancellationToken)
        {
            var username= _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(username))
                throw new UnauthorizedAccessException("not authorized");

            var user = await _userService.GetUserByName(username);
            if (user == null)
                throw new Exception("User not found");
            user.Wallet = request.Amount;
            var updatedUser= await _userService.UpdateUser(user);
            return updatedUser;



        }
    }
}
