using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookManagement.Application.Features.Commands.users
{
    public class UpgradeMembershipCommandHandler : IRequestHandler<UpgradeMembershipCommand,bool>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpgradeMembershipCommandHandler(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {

            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));


        }

        public async Task<bool> Handle(UpgradeMembershipCommand command, CancellationToken cancellationToken)
        {
            var username = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(username))
                throw new UnauthorizedAccessException("Not authorized");

            return await _userService.UpgradeMembershipAsync(username, command.Month);
        }
    }
}
