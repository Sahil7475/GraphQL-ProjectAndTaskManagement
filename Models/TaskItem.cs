namespace ProjectAndTaskManagement.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "ToDo";
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public int? AssigneeId { get; set; }
        public User? Assignee { get; set; }
    }
}
