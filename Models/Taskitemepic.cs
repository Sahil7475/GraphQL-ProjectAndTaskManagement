using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Taskitemepic
{
    public int Id { get; set; }

    public int? Taskitemid { get; set; }

    public int? Epicid { get; set; }

    public virtual Epic? Epic { get; set; }

    public virtual TaskItem? Taskitem { get; set; }
}
