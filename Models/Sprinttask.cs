using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Sprinttask
{
    public int Id { get; set; }

    public int? Sprintid { get; set; }

    public int? Taskitemid { get; set; }

    public virtual Sprint? Sprint { get; set; }

    public virtual TaskItem? Taskitem { get; set; }
}
