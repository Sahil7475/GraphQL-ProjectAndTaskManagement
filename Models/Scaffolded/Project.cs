using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models.Scaffolded;

public partial class Project
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}
