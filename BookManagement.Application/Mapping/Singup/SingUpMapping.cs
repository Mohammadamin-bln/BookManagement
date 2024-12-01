using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookManagement.Application.Features.Command;
using BookManagement.Domain.Enitiy;
using static BookManagement.Domain.Enum.Enums;

namespace BookManagement.Application.Mapping.SingupMapping
{
    public class SingUpMapping : Profile
    {
        public SingUpMapping()
        {
            CreateMap<SingupCommand, Users>()
                .ForMember(dest => dest.MemberShipType, opt => opt.MapFrom(src => MemberShipType.Admin));

        }
    }
}
