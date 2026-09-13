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
                isExists = item.FindProperty("DeletedAt");
                isExists?.SetDefaultValueSql("null");
            }
            modelBuilder.Entity<Departments>().HasKey(e => e.Id);
            modelBuilder.Entity<Roles>().HasKey(r => r.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Permissions>().HasKey(x => x.Id);
            modelBuilder.Entity<Projects>().HasKey(x => x.Id);
            modelBuilder.Entity<ProjectTasks>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskDbStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<UserProfile>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            modelBuilder.Entity<UserProfile>().HasOne(uf => uf.User).WithOne(u => u.UserProfile).HasForeignKey<UserProfile>(uf => uf.UserId);

            modelBuilder.Entity<UserDepartments>().HasKey(ud => new
            {
                ud.UserId,
                ud.DepartmentId
            });
            modelBuilder.Entity<UserDepartments>().HasOne(x => x.User).WithMany(x => x.UserDepartments).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserDepartments>().HasOne(x => x.Department).WithMany(x => x.UserDepartments).HasForeignKey(x => x.DepartmentId);
            modelBuilder.Entity<Projects>().HasOne(x => x.Departmnt).WithMany(x => x.Projects).HasForeignKey(x => x.DepartmentId);
            modelBuilder.Entity<ProjectTasks>().HasOne(x => x.Project).WithMany(x => x.Tasks).HasForeignKey(x => x.ProjectId);
            modelBuilder.Entity<ProjectTasks>().HasOne(x => x.AssignUser).WithMany(x => x.ProjectTasks).HasForeignKey(x => x.ProjectId);
            modelBuilder.Entity<ProjectTasks>().HasOne(x => x.Status).WithMany(x => x.ProjectTasks).HasForeignKey(x => x.StatusId);
            modelBuilder.Entity<Permissions>().HasKey(p => new { p.Id });
            modelBuilder.Entity<RolePermissions>().HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<RolePermissions>().HasOne(x => x.Role).WithMany(x => x.Permissions).HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<RolePermissions>().HasOne(x => x.Permission).WithMany(x => x.RolePermissions).HasForeignKey(x => x.PermissionId);

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, Role = "Super Admin", CreatedAt = new DateTime(2026, 1, 1, 1, 1, 1), UpdatedAt = new DateTime(2026, 1, 1, 1, 1, 1) },
                new Roles { Id = 2, Role = "Admin", CreatedAt = new DateTime(2026, 1, 1, 1, 1, 1), UpdatedAt = new DateTime(2026, 1, 1, 1, 1, 1) },
                new Roles { Id = 3, Role = "User", CreatedAt = new DateTime(2026, 1, 1, 1, 1, 1), UpdatedAt = new DateTime(2026, 1, 1, 1, 1, 1) }
            );
            modelBuilder.Entity<Permissions>().HasData(
                new Permissions
                {
                    Id = 1,
                    Name = "User.View",
                    Description = "View users",
                    Category = "User"
                },

                new Permissions
                {
                    Id = 2,
                    Name = "User.Create",
                    Description = "Create users",
                    Category = "User"
                },

                new Permissions
                {
                    Id = 3,
                    Name = "User.Edit",
                    Description = "Edit users",
                    Category = "User"
                },

                new Permissions
                {
                    Id = 4,
                    Name = "User.Delete",
                    Description = "Delete users",
                    Category = "User"
                },

                new Permissions
                {
                    Id = 5,
                    Name = "Department.View",
                    Description = "View departments",
                    Category = "Department"
                },

                new Permissions
                {
                    Id = 6,
                    Name = "Department.Create",
                    Description = "Create departments",
                    Category = "Department"
                },

                new Permissions
                {
                    Id = 7,
                    Name = "Department.Edit",
                    Description = "Edit departments",
                    Category = "Department"
                },

                new Permissions
                {
                    Id = 8,
                    Name = "Department.Delete",
                    Description = "Delete departments",
                    Category = "Department"
                },

                new Permissions
                {
                    Id = 9,
                    Name = "Project.View",
                    Description = "View projects",
                    Category = "Project"
                },

                new Permissions
                {
                    Id = 10,
                    Name = "Project.Create",
                    Description = "Create projects",
                    Category = "Project"
                },

                new Permissions
                {
                    Id = 11,
                    Name = "Project.Edit",
                    Description = "Edit projects",
                    Category = "Project"
                },

                new Permissions
                {
                    Id = 12,
                    Name = "Project.Delete",
                    Description = "Delete projects",
                    Category = "Project"
                },

                new Permissions
                {
                    Id = 13,
                    Name = "Task.View",
                    Description = "View tasks",
                    Category = "Task"
                },

                new Permissions
                {
                    Id = 14,
                    Name = "Task.Create",
                    Description = "Create tasks",
                    Category = "Task"
                },

                new Permissions
                {
                    Id = 15,
                    Name = "Task.Edit",
                    Description = "Edit tasks",
                    Category = "Task"
                },

                new Permissions
                {
                    Id = 16,
                    Name = "Task.Delete",
                    Description = "Delete tasks",
                    Category = "Task"
                },

                new Permissions
                {
                    Id = 17,
                    Name = "Task.Assign",
                    Description = "Assign tasks",
                    Category = "Task"
                }
            );

            modelBuilder.Entity<RolePermissions>().HasData(
                new RolePermissions { RoleId = 1, PermissionId = 1 },
                new RolePermissions { RoleId = 1, PermissionId = 2 },
                new RolePermissions { RoleId = 1, PermissionId = 3 },
                new RolePermissions { RoleId = 1, PermissionId = 4 },
                new RolePermissions { RoleId = 1, PermissionId = 5 },
                new RolePermissions { RoleId = 1, PermissionId = 6 },
                new RolePermissions { RoleId = 1, PermissionId = 7 },
                new RolePermissions { RoleId = 1, PermissionId = 8 },
                new RolePermissions { RoleId = 1, PermissionId = 9 },
                new RolePermissions { RoleId = 1, PermissionId = 10 },
                new RolePermissions { RoleId = 1, PermissionId = 11 },
                new RolePermissions { RoleId = 1, PermissionId = 12 },
                new RolePermissions { RoleId = 1, PermissionId = 13 },
                new RolePermissions { RoleId = 1, PermissionId = 14 },
                new RolePermissions { RoleId = 1, PermissionId = 15 },
                new RolePermissions { RoleId = 1, PermissionId = 16 },
                new RolePermissions { RoleId = 1, PermissionId = 17 },
                new RolePermissions { RoleId = 2, PermissionId = 1 },
                new RolePermissions { RoleId = 2, PermissionId = 2 },
                new RolePermissions { RoleId = 2, PermissionId = 3 },
                new RolePermissions { RoleId = 2, PermissionId = 9 },
                new RolePermissions { RoleId = 2, PermissionId = 10 },
                new RolePermissions { RoleId = 2, PermissionId = 11 },
                new RolePermissions { RoleId = 2, PermissionId = 12 },
                new RolePermissions { RoleId = 2, PermissionId = 13 },
                new RolePermissions { RoleId = 2, PermissionId = 14 },
                new RolePermissions { RoleId = 2, PermissionId = 15 },
                new RolePermissions { RoleId = 2, PermissionId = 16 },
                new RolePermissions { RoleId = 2, PermissionId = 17 },
                new RolePermissions { RoleId = 3, PermissionId = 1 },
                new RolePermissions { RoleId = 3, PermissionId = 9 },
                new RolePermissions { RoleId = 3, PermissionId = 13 },
                new RolePermissions { RoleId = 3, PermissionId = 14 },
                new RolePermissions { RoleId = 3, PermissionId = 15 }
            );
        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<UserDepartments> UserDepartments { get; set; }
    }
}
