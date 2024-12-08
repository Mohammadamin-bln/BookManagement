using BookManagement.Application.Responses;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Infrastructure.Repository.Interfaces;

namespace BookManagement.Application.Services.Implements;

public class OtpService : IOtpService
{
    private readonly IOtpRepository _repository;

    public OtpService(IOtpRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<SignUpResponse> SaveOtpRequest(int userId, string userName, string otp)
    {
        try
        {
            await _repository.SaveOtpRequest(userId, otp, DateTime.UtcNow.AddMinutes(2));
            return new SignUpResponse
            {
                UserId = userId,
                Username = userName,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(2) 
            };
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Otp save failed: {e.Message}");
        }
    }

    public async Task<bool> ValidateOtpRequest(int userId, string otp)
    {
        try
        {
            return await _repository.ValidateOtpRequest(userId, otp);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"OTP validation failed: {e.Message}");
        }
    }
}

