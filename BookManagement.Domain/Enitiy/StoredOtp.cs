using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Enitiy
{
    public class StoredOtp
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Otp { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
