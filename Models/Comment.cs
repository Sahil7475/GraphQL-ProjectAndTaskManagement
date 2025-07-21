using System;
using System.Collections.Generic;

namespace ProjectAndTaskManagement.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public int? AuthorId { get; set; }

    public int? TaskItemId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? Author { get; set; }

    public virtual TaskItem? TaskItem { get; set; }
}
