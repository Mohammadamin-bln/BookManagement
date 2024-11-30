using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookManagement.Domain.Enitiy;
using MediatR;
using BookManagement.Application.InterFace;
using BookManagement.Application.Features.Command;


namespace BookManagement.Application.Features.Commands
{
    public class SignUpCommandHandler : IRequestHandler<SingupCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SignUpCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<int> Handle(SingupCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Users>(request);
            await _userRepository.AddUserAsync(user);
            return user.Id;
        }
    }
}
