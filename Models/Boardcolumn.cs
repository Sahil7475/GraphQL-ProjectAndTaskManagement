using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Boardcolumn
{
    public int Id { get; set; }

    public int? Boardid { get; set; }

    public string? Name { get; set; }

    public int? Orderindex { get; set; }

    public virtual Projectboard? Board { get; set; }

    public virtual ICollection<Boardtask> Boardtasks { get; set; } = new List<Boardtask>();
}
