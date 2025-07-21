using ProjectAndTaskManagement.Models;
using Tag = ProjectAndTaskManagement.Models.Tag;

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
                await context.SaveChangesAsync();
            }

            if (!context.Projects.Any())
            {
                var projects = new List<Project>
                {
                    new() { Title = "GraphQL API", Description = "Build GraphQL with Hot Chocolate" },
                    new() { Title = "Frontend UI", Description = "Design task board UI" }
                };
                context.Projects.AddRange(projects);
                await context.SaveChangesAsync();
            }

            if (!context.Projectboards.Any())
            {
                var board = new Projectboard { Name = "Default Board", Projectid = context.Projects.First().Id };
                context.Projectboards.Add(board);
                await context.SaveChangesAsync();
            }

            if (!context.Boardcolumns.Any())
            {
                var boardId = context.Projectboards.First().Id;
                var columns = new List<Boardcolumn>
                {
                    new() { Name = "To Do", Orderindex = 1, Boardid = boardId },
                    new() { Name = "In Progress", Orderindex = 2, Boardid = boardId },
                    new() { Name = "Done", Orderindex = 3, Boardid = boardId }
                };
                context.Boardcolumns.AddRange(columns);
                await context.SaveChangesAsync();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Bug", Description = "Bug report" },
                    new Category { Name = "Feature", Description = "New feature request" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Priorities.Any())
            {
                context.Priorities.AddRange(
                    new Priority { Level = "High" },
                    new Priority { Level = "Medium" },
                    new Priority { Level = "Low" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.TaskItems.Any())
            {
                var project = context.Projects.First();
                var user = context.Users.First();
                var cat = context.Categories.First();
                var priority = context.Priorities.First();

                var tasks = new List<TaskItem>
                {
                    new() { Title = "Setup DB", ProjectId = project.Id, AssigneeId = user.Id, CategoryId = cat.Id, PriorityId = priority.Id,Status = "In Progress" },
                    new() { Title = "Create Mutation", ProjectId = project.Id, AssigneeId = user.Id, CategoryId = cat.Id, PriorityId = priority.Id, Status = "Done"},
                    new() { Title = "Build UI", ProjectId = project.Id, CategoryId = cat.Id,Status = "To Do" }
                };

                context.TaskItems.AddRange(tasks);
                await context.SaveChangesAsync();
            }

            if (!context.Boardtasks.Any())
            {
                var column = context.Boardcolumns.First();
                var task = context.TaskItems.First();
                context.Boardtasks.Add(new Boardtask { Columnid = column.Id, Taskitemid = task.Id });
                await context.SaveChangesAsync();
            }

            if (!context.Tags.Any())
            {
                var tag = new Tag { Name = "Urgent" };
                context.Tags.Add(tag);
                await context.SaveChangesAsync();
            }

            if (!context.Comments.Any())
            {
                var user = context.Users.First();
                var task = context.TaskItems.First();
                context.Comments.Add(new Comment { Content = "Initial setup done", AuthorId = user.Id, TaskItemId = task.Id });
                await context.SaveChangesAsync();
            }

            if (!context.Epics.Any())
            {
                var project = context.Projects.First();
                context.Epics.Add(new Epic { Title = "Epic 1", Description = "Large Feature", Projectid = project.Id });
                await context.SaveChangesAsync();
            }

            if (!context.Taskitemepics.Any())
            {
                var task = context.TaskItems.First();
                var epic = context.Epics.First();
                context.Taskitemepics.Add(new Taskitemepic { Taskitemid = task.Id, Epicid = epic.Id });
                await context.SaveChangesAsync();
            }

            if (!context.Sprints.Any())
            {
                var project = context.Projects.First();
                context.Sprints.Add(new Sprint
                {
                    Name = "Sprint 1",
                    Projectid = project.Id,
                    Startdate = DateOnly.FromDateTime(DateTime.UtcNow),
                    Enddate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(14))
                });
                await context.SaveChangesAsync();
            }

            if (!context.Sprinttasks.Any())
            {
                var task = context.TaskItems.First();
                var sprint = context.Sprints.First();
                context.Sprinttasks.Add(new Sprinttask { Taskitemid = task.Id, Sprintid = sprint.Id });
                await context.SaveChangesAsync();
            }

            if (!context.Storypoints.Any())
            {
                var task = context.TaskItems.First();
                context.Storypoints.Add(new Storypoint { Points = 5, Taskitemid = task.Id });
                await context.SaveChangesAsync();
            }
        }
    }
}
