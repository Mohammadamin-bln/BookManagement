using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookManagement.Application.Features.Commands;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Application.Mapping.Book
{
    public class AddBookMapping : Profile
    {
        public AddBookMapping()
        {
            CreateMap<AddBookCommand, Books>();
        }
    }
}
