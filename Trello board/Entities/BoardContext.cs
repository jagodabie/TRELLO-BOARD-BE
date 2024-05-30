using Microsoft.EntityFrameworkCore;
using Trello_board.Entities;
using Trello_board.Models;


public class BoardContext : DbContext
{
    public BoardContext(DbContextOptions<BoardContext> options)
        : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<TasksGroup> TasksGroups { get; set; }
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Workspace>(
            entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.AuthorId).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("getdate()");
                entity.HasOne(e => e.Author).WithOne().HasForeignKey<Workspace>(e => e.AuthorId).OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(e => e.TasksGroup).WithOne(e => e.Workspace).HasForeignKey(e => e.WorkspaceId).OnDelete(DeleteBehavior.Restrict);
            });

        modelBuilder.Entity<TasksGroup>(
            entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.WorkspaceId).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Author).WithOne().HasForeignKey<TasksGroup>(e => e.AuthorId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Workspace).WithMany(e => e.TasksGroup).HasForeignKey(e => e.WorkspaceId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.Tasks).WithOne(e => e.TasksGroup).HasForeignKey(e => e.TasksGroupId).OnDelete(DeleteBehavior.Restrict);

            });
        modelBuilder.Entity<Task>(
            entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.TasksGroupId).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("getdate()");
                entity.HasOne(e => e.Author).WithOne().HasForeignKey<Task>(e => e.AuthorId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.TasksGroup).WithMany(e => e.Tasks).HasForeignKey(e => e.TasksGroupId).OnDelete(DeleteBehavior.NoAction);
            });

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Jagoda Bieniek", Email = "jagoda.bieniek1234@gmail.com" },
            new User { Id = 2, Name = "John Doe", Email = "jan@gmail.com" });
    }

}