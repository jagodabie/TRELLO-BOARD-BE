namespace Trello_board.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TasksGroupId { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
        public string? DueDate { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }

        public Task(int id, string name, string tasksGroupId, string userId, string status, string dueDate, string createdAt, string updatedAt)
        {
            Id = id;
            Name = name;
            TasksGroupId = tasksGroupId;
            UserId = userId;
            Status = status;
            DueDate = dueDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}