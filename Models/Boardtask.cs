using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Boardtask
{
    public int Id { get; set; }

    public int? Taskitemid { get; set; }

    public int? Columnid { get; set; }

    public DateTime? Movedat { get; set; }

    public virtual Boardcolumn? Column { get; set; }

    public virtual TaskItem? Taskitem { get; set; }
}
