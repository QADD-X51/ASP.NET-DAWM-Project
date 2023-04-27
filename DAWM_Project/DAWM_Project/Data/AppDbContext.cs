using DAWM_Project.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAWM_Project.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseSqlServer("Server=DESKTOP-LHAQ4GH;Database=DAWMProj;User Id=useradmin;Password=1q2w3e;TrustServerCertificate=True;")
                    .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
