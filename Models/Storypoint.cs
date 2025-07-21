using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Storypoint
{
    public int Id { get; set; }

    public int? Taskitemid { get; set; }

    public int? Points { get; set; }

    public virtual TaskItem? Taskitem { get; set; }
}
