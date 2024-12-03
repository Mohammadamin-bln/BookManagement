using BookManagement.Domain.Enitiy;

using MediatR;
using BookManagement.Application.Responses;
using BookManagement.Application.Services.Interfaces;


namespace BookManagement.Application.Features.Commands.users
{
    public class SignUpCommandHandler : IRequestHandler<SingupCommand, SignUpResponse>
    {
        private readonly IUserService _service;
        private readonly IOtpService _otpService;

        public SignUpCommandHandler(IUserService service, IOtpService otpService)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _otpService = otpService ?? throw new ArgumentNullException(nameof(otpService));
        }

        public async Task<SignUpResponse> Handle(SingupCommand request, CancellationToken cancellationToken)
        {
            Users user = await _service.AddUser(request);

            var otp = GenerateOtp();

            var result = await _otpService.SaveOtpRequest(user.Id, user.Username, otp);

            return result;
        }

        private string GenerateOtp()
        {
            return new Random().Next(100000, 999999).ToString();
        }
    }
}
