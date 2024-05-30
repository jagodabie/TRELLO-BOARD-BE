using Trello_board.Models;

namespace Trello_board.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Workspace Workspace { get; set; }
        public TasksGroup TasksGroup { get; set; }
        public Task Task { get; set; }
        public string UserId { get; set; }
    }
}
