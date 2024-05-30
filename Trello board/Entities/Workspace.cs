using System;
using System.Collections.Generic;
using Trello_board.Entities;

namespace Trello_board.Models;

public class Workspace
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User Author { get; set; }
    public int AuthorId { get; set; }
    public List<TasksGroup> TasksGroup { get; set; } = new List<TasksGroup>();
}
