using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Sprint
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public int? Projectid { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<Sprinttask> Sprinttasks { get; set; } = new List<Sprinttask>();
}
