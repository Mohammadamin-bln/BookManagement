using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enum;

namespace BookManagement.Domain.Enitiy
{
    public class Users
    {

        public int Id { get; set; }

        public required string Username { get; set; }
        public required string Password { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public  Enums.MemberShipType MemberShipType { get; set; }

        public int Wallet { get; set; } = 0;
    }
}
