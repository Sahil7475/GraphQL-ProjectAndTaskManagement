using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Projectboard
{
    public int Id { get; set; }

    public int? Projectid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Boardcolumn> Boardcolumns { get; set; } = new List<Boardcolumn>();

    public virtual Project? Project { get; set; }
}
