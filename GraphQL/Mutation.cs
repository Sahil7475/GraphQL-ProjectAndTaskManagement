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

        public async Task<Category> CreateCategoryAsync(
            string name,string description,
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();

            var category = new Category
            {
                Name = name,
                Description = description
            };

            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return category;
        }

        public async Task<Epic> CreateEpicAsync(
                string? title,
                string? description,
                int? projectId,
                [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();

            var epic = new Epic
            {
                Title = title,
                Description = description,
                Projectid = projectId
            };

            db.Epics.Add(epic);
            await db.SaveChangesAsync();
            return epic;
        }


        public async Task<Projectboard> CreateProjectboardAsync(
                int? projectId,
                string? name,
                [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();

            var board = new Projectboard
            {
                Projectid = projectId,
                Name = name
            };

            db.Projectboards.Add(board);
            await db.SaveChangesAsync();
            return board;
        }

        public async Task<Sprint> CreateSprintAsync(
                [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();

            var sprint = new Sprint();

            db.Sprints.Add(sprint);
            await db.SaveChangesAsync();
            return sprint;
        }


    }
}
