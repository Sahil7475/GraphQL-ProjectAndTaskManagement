using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int ProjectId { get; set; }

    public int? AssigneeId { get; set; }

    public int? CategoryId { get; set; }

    public int? PriorityId { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public int? ParentTaskId { get; set; }

    public virtual User? Assignee { get; set; }

    public virtual ICollection<Boardtask> Boardtasks { get; set; } = new List<Boardtask>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<TaskItem> InverseParentTask { get; set; } = new List<TaskItem>();

    public virtual TaskItem? ParentTask { get; set; }

    public virtual Priority? Priority { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<Sprinttask> Sprinttasks { get; set; } = new List<Sprinttask>();

    public virtual ICollection<Storypoint> Storypoints { get; set; } = new List<Storypoint>();

    public virtual ICollection<Taskitemepic> Taskitemepics { get; set; } = new List<Taskitemepic>();

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
