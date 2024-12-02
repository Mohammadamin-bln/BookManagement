﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookManagement.Application.Features.Commands.books;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Application.Services.Interfaces
{
    public interface IBookService
    {
        public Task<Books> AddBook(AddBookCommand request);
    }
}
