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
using static BookManagement.Domain.Enum.Enums;
using BookManagement.Application.Responses;


namespace BookManagement.Application.Features.Commands
{
    public class SignUpCommandHandler : IRequestHandler<SingupCommand, SignUpResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private readonly IOtpRepository _otpRepository;

        public SignUpCommandHandler(IUserRepository userRepository, IMapper mapper,  IOtpRepository otpRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;

            _otpRepository = otpRepository;

        }

        public async Task<SignUpResponse> Handle(SingupCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Users>(request);

           
            user.MemberShipType = MemberShipType.Normal;

            await _userRepository.AddUserAsync(user);

            var otp = GenerateOtp();

            await _otpRepository.SaveOtpForUserAsync(user.Id, otp, DateTime.UtcNow.AddMinutes(2));
            return new SignUpResponse
            {
                UserId = user.Id,
                Username = user.Username,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(2) // Expiration time of OTP
            };
        }
        private string GenerateOtp()
        {

            var otp = new Random().Next(100000, 999999).ToString();
            return otp;
        }


    }
}
