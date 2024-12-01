using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.InterFace;
using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Repository
{
    public class OtpRepository : IOtpRepository
    {
        private readonly ApplicationDbContext _context;

        public OtpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveOtpForUserAsync(int userId, string otp, DateTime expiryTime)
        {
            var otpEntity = new StoredOtp
            {
                UserId = userId,
                Otp = otp,
                ExpiryTime = expiryTime 
            };

            _context.StoredOtps.Add(otpEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateOtpForUserAsync(int userId, string otp)
        {
            var otpEntity = await _context.StoredOtps
                .Where(o => o.UserId == userId && o.Otp == otp)
                .FirstOrDefaultAsync();

            return otpEntity != null && otpEntity.ExpiryTime >= DateTime.UtcNow;
        }
    }
}
