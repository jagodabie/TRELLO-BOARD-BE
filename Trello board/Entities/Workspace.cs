namespace Trello_board.Models;

public class Workspace
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CreatedAt { get; set; }
    public string? UpdatedAt { get; set; }
    public string UserId { get; set; }


    public List<TasksGroup> TasksGroups { get; set; }

    public Workspace(string id, string name, string createdAt, string updatedAt, List<TasksGroup> tasksGroups, string userId)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        TasksGroups = tasksGroups;
        UserId = userId;
    }
}
