using Microsoft.EntityFrameworkCore;


public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
    {
    }

    public DbSet<Trello_board.Models.Task> Tasks { get; set; }
    public DbSet<Trello_board.Models.TasksGroup> TasksGroups { get; set; }
    public DbSet<Trello_board.Models.Workspace> Workspaces { get; set; }



}