using MicroPlate.JwtAuthenticationManager.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroPlate.JwtAuthenticationManager.Data
{
    public class AuthenticationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MicroPlate.Users");
        }
        public DbSet<UserAccount> Users { get; set; }
    }
}
