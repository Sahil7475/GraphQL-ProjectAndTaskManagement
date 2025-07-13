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

    public virtual User? Assignee { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Project Project { get; set; } = null!;
}
