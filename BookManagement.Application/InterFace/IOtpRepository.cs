using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enitiy;

namespace BookManagement.Application.InterFace
{
    public interface IOtpRepository
    {
        Task SaveOtpForUserAsync(int userId, string otp, DateTime expiryTime);
        Task<bool> ValidateOtpForUserAsync(int userId, string otp);
    }
}
