﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Features.Queries.Signin
{
    public class SingInQuery : IRequest<string>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Otp { get; set; }
    }
}