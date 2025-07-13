﻿namespace ProjectAndTaskManagement.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<TaskItem> Tasks { get; set; } = new();
    }
}
