using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Project
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Epic> Epics { get; set; } = new List<Epic>();

    public virtual ICollection<Projectboard> Projectboards { get; set; } = new List<Projectboard>();

    public virtual ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}
