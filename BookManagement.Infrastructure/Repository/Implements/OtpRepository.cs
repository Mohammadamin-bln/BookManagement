using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Context;
using BookManagement.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Repository
{
    public class OtpRepository(ApplicationDbContext context) : IOtpRepository
    {
        public async Task SaveOtpRequest(int userId,string otp,DateTime expiry)
        {
            var otpEntity = new StoredOtp
            {
                UserId = userId,
                Otp = otp,
                ExpiryTime = expiry 
            };

            context.StoredOtps.Add(otpEntity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ValidateOtpRequest(int userId, string otp)
        {
            var otpEntity = await context.StoredOtps
                .Where(o => o.UserId == userId && o.Otp == otp)
                .FirstOrDefaultAsync();

            return otpEntity != null && otpEntity.ExpiryTime >= DateTime.UtcNow;
        }
    }
}
