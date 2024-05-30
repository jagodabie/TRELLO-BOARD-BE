

using System;
using System.Collections.Generic;
using Trello_board.Entities;
using Trello_board.Models;

public class TasksGroup
{
    public int Id;
    public string Name;
    public int WorkspaceId;
    public Workspace Workspace { get; set; }
    public int AuthorId { get; set; }
    public User Author { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<Task> Tasks { get; set; } = new List<Task>();

}