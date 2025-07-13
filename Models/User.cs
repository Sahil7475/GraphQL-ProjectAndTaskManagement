using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}
