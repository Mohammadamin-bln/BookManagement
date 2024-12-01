using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enitiy;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Users> Users { get; set; }

        public DbSet<StoredOtp> StoredOtps { get; set; }
    }
}
