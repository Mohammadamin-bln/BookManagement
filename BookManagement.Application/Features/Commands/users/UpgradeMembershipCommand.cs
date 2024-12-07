using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookManagement.Application.Features.Commands.users
{
    public class UpgradeMembershipCommand : IRequest<bool>
    {
        public int Month { get; set; } 
    }
}
