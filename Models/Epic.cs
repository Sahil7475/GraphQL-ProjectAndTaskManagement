using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Epic
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Projectid { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<Taskitemepic> Taskitemepics { get; set; } = new List<Taskitemepic>();
}
