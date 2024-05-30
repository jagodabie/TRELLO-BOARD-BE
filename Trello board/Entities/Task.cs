using System;
using Trello_board.Entities;

namespace Trello_board.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TasksGroupId { get; set; }
        public TasksGroup TasksGroup { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public string Status { get; set; }
        public string DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}