using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Contexts;

public class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region ConfigTables
        modelBuilder.Entity<UserModel>(user =>
        {
            user.HasKey(u => u.UserId);
            user.Property(u => u.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<ProjectModel>(project =>
        {
            project.HasKey(p => p.ProjectId);
            project.Property(p => p.ProjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<TaskModel>(task =>
        {
            task.HasKey(t => t.TaskId);
            task.Property(t => t.TaskName).HasMaxLength(50);
        });
        #endregion
        #region Relations
        modelBuilder.Entity<ProjectModel>()
            .HasOne(p => p.User)
            .WithMany(u => u.UserProjects)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TaskModel>()
            .HasOne(t => t.Project)
            .WithMany(p => p.ProjectTasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
        #region SeedData
        modelBuilder.Entity<UserModel>()
            .HasData(
            new UserModel { UserId = 1, Username = "user1" },
            new UserModel { UserId = 2, Username = "user2"});
        #endregion

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<TaskModel> Tasks { get; set; }
    public DbSet<ProjectModel> Projects { get; set; }
    public DbSet<UserModel> Users { get; set; }
}