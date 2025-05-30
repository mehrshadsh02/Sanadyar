using Microsoft.EntityFrameworkCore;
using LandingApp.Models;


namespace LandingApp.Data
{
    public class SanadyarDbContext : DbContext
    {
        public SanadyarDbContext(DbContextOptions<SanadyarDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // نقش‌ها
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", DisplayName = "مدیر سیستم" },
                new Role { Id = 2, RoleName = "FinancialUser", DisplayName = "کاربر مالی" },
                new Role { Id = 3, RoleName = "HRUser", DisplayName = "کاربر حقوق و دستمزد" },
                new Role { Id = 4, RoleName = "WarehouseUser", DisplayName = "کاربر انبارداری" }
            );

            // کاربران
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "123" },
                new User { Id = 2, Username = "finance", Password = "123" },
                new User { Id = 3, Username = "hr", Password = "123" }
            );

            // تخصیص نقش به کاربر
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1 }, // admin → Admin
                new UserRole { UserId = 1, RoleId = 2 }, // admin → Financial
                new UserRole { UserId = 1, RoleId = 3 }, // admin → HR

                new UserRole { UserId = 2, RoleId = 2 }, // finance → Financial
                new UserRole { UserId = 3, RoleId = 3 }  // hr → HR
            );
        }
    }

}
