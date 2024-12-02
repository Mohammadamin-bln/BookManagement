using BookManagement.Domain.Enitiy;

using MediatR;
using BookManagement.Application.Features.Command;
using BookManagement.Application.Responses;
using BookManagement.Application.Services.Interfaces;


namespace BookManagement.Application.Features.Commands
{
    public class SignUpCommandHandler(IUserService service,IOtpService otpService) : IRequestHandler<SingupCommand, SignUpResponse>
    {
        private readonly IUserService _service = service;
        private readonly IOtpService _otpService = otpService;

        public async Task<SignUpResponse> Handle(SingupCommand request, CancellationToken cancellationToken)
        {
            Users user = await _service.AddUser(request);

            var otp = GenerateOtp();

            var result = await _otpService.SaveOtpRequest(user.Id,user.Username, otp);
            
            return result;
        }
        private string GenerateOtp()
        {
            var otp = new Random().Next(100000, 999999).ToString();
            return otp;
        }


    }
}
