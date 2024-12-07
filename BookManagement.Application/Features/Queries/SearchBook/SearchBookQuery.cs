﻿using BookManagement.Domain.Enitiy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Features.Queries.SearchBook
{
    public class SearchBookQuery : IRequest<Books>
    {
        public string BookName { get; set; }
    }
}