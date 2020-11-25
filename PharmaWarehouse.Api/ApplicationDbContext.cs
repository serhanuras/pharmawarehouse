using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PharmaWarehouse.Api.Entities;
using PharmaWarehouse.Api.Modules.Extensions;

namespace PharmaWarehouse.Api
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext()
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL($"Host=pharmawarehouse.cekx2hjymq02.us-east-2.rds.amazonaws.com;Port=3306;User=admin;Password=SDFwer741!;Database=pharmawarehousedb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId);
        }
    }
}
