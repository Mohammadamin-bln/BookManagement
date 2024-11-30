using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookManagement.Application.Features.Command
{
    public class SingupCommand : IRequest<int>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
    }
}
