namespace ProjectAndTaskManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Role { get; set; } = "Member";
        public List<TaskItem> AssignedTasks { get; set; } = new();

    }
}
