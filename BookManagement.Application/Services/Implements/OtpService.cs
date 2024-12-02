using BookManagement.Application.Responses;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Infrastructure.Repository.Interfaces;

namespace BookManagement.Application.Services.Implements;

public class OtpService(IOtpRepository repository) : IOtpService
{
    private readonly IOtpRepository _repository = repository;

    public async Task<SignUpResponse> SaveOtpRequest(int userId,string userName, string otp)
    {
        try
        {
            await _repository.SaveOtpRequest(userId, otp, DateTime.UtcNow.AddMinutes(2));
            return new SignUpResponse
            {
                UserId = userId,
                Username = userName,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(2) // Expiration time of OTP
            };
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Otp save failed: {e.Message}");
        }
    }

    public async Task<bool> ValidateOtpRequest(int userId, string otp)
    {
        throw new NotImplementedException();
    }
}