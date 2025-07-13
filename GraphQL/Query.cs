using ProjectAndTaskManagement.Data;
using ProjectAndTaskManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectAndTaskManagement.GraphQL
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Project>> GetProjects(
        [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Projects.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<TaskItem>> GetTasks(
        [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.TaskItems.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<User>> GetUsers(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Users.AsQueryable();
        }
    }
}
