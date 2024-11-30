﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Application.InterFace
{
    public interface IUserRepository
    {
        Task AddUserAsync(Users user);
        Task<bool> ValidateUserAsync(string username, string password);
    }
}