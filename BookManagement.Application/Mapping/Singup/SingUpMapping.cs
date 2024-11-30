using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookManagement.Application.Features.Command;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Application.Mapping.SingupMapping
{
    public class SingUpMapping : Profile
    {
        public SingUpMapping()
        {
            CreateMap<SingupCommand, Users>();
        }
    }
}
