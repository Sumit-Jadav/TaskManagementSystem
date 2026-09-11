using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    public class TaskManagementContext(DbContextOptions<TaskManagementContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes();
            foreach (var item in allEntities)
            {
                var isExists = item.FindProperty("CreatedAt");
                isExists?.SetDefaultValueSql("SYSUTCDATETIME()");
                isExists = item.FindProperty("UpdatedAt");
                isExists?.SetDefaultValueSql("SYSUTCDATETIME()");
                isExists = item.FindProperty("DeletedAt");
                isExists?.SetDefaultValueSql("null");
                isExists = item.FindProperty("DeactivatedAt");
                isExists?.SetDefaultValueSql("null");
            }
            modelBuilder.Entity<Roles>().HasKey(r => r.Id);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            modelBuilder.Entity<UserProfile>().HasOne(uf => uf.User).WithOne(u => u.UserProfile).HasForeignKey<UserProfile>(uf => uf.UserId);
            
        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
