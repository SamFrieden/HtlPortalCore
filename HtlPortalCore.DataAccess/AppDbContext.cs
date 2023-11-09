using HtlPortalCore.DataAccess.Entities;
using HtlPortalCore.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;

namespace HtlPortalCore.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Portal");

            builder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<UserEntity>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();

            builder.Entity<UserEntity>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            SeedData.AddAdminUsers(builder);
        }
    }
}