using BookManagement.Application.Responses;

namespace BookManagement.Application.Services.Interfaces;

public interface IOtpService
{
    public Task<SignUpResponse> SaveOtpRequest(int userId,string userName, string otp);
    public Task<bool> ValidateOtpRequest(int userId, string otp);
}