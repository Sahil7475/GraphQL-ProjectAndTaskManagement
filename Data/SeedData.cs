using ProjectAndTaskManagement.Models;

namespace ProjectAndTaskManagement.Data
{
    public class SeedData
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
            {
                new() { Name = "Sahil", Role = "Admin" },
                new() { Name = "Alice", Role = "Member" },
                new() { Name = "Bob", Role = "Member" }
            };
                context.Users.AddRange(users);
            }

            if (!context.Projects.Any())
            {
                var projects = new List<Project>
            {
                new() { Title = "GraphQL API", Description = "Build GraphQL with Hot Chocolate" },
                new() { Title = "Frontend UI", Description = "Design task board UI" }
            };
                context.Projects.AddRange(projects);
            }

            await context.SaveChangesAsync(); 

            if (!context.TaskItems.Any())
            {
                var project = context.Projects.First();
                var user = context.Users.First();

                var tasks = new List<TaskItem>
            {
                new() { Title = "Setup DB", Status = "ToDo", ProjectId = project.Id, AssigneeId = user.Id },
                new() { Title = "Create Mutation", Status = "InProgress", ProjectId = project.Id, AssigneeId = user.Id },
                new() { Title = "Build UI", Status = "ToDo", ProjectId = project.Id, AssigneeId = null }
            };
                context.TaskItems.AddRange(tasks);
            }

            await context.SaveChangesAsync();
        }
    }
}
