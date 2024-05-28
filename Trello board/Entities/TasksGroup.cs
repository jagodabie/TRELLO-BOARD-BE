

namespace Trello_board.Models
{
    public class TasksGroup
    {
        public int Id;
        public string Name;

        public string WorkspaceId;

        public string? UserId { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }

        public List<Task> Tasks { get; set; }

        public TasksGroup(int id, string name, string workspaceId, string userId, string createdAt, string updatedAt, List<Task> tasks)
        {
            Id = id;
            Name = name;
            WorkspaceId = workspaceId;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Tasks = tasks;
        }


    }
}
