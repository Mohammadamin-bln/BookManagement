namespace BookManagement.Infrastructure.Repository.Interfaces;

public interface IOtpRepository
{
    public Task SaveOtpRequest(int userId,string otp,DateTime expiry);
    public Task<bool> ValidateOtpRequest(int userId, string otp);
}