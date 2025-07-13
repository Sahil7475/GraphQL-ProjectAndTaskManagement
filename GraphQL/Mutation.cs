using ProjectAndTaskManagement.Data;
using ProjectAndTaskManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectAndTaskManagement.GraphQL
{
    public class Mutation
    {
        public async Task<Project> CreateProjectAsync(
         string title,
         string description,
         [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();

            var project = new Project
            {
                Title = title,
                Description = description
            };

            db.Projects.Add(project);
            await db.SaveChangesAsync();
            return project;
        }

        public async Task<User> CreateUserAsync(
            string name,
            string role,
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();

            var user = new User
            {
                Name = name,
                Role = role
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<TaskItem> CreateTaskAsync(
            string title,
            string status,
            int projectId,
            int? assigneeId,
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();

            var task = new TaskItem
            {
                Title = title,
                Status = status,
                ProjectId = projectId,
                AssigneeId = assigneeId
            };

            db.TaskItems.Add(task);
            await db.SaveChangesAsync();
            return task;
        }
    }
}
