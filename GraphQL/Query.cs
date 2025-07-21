using ProjectAndTaskManagement.Data;
using ProjectAndTaskManagement.Models;
using Microsoft.EntityFrameworkCore;
using Tag = ProjectAndTaskManagement.Models.Tag;

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
        [Service] IDbContextFactory<AppDbContext> dbContextFactory,int? assigneeId)
        {
            var db = await dbContextFactory.CreateDbContextAsync();

            if (assigneeId.HasValue)
            {
                return db.TaskItems.Where(t => t.AssigneeId == assigneeId.Value).AsQueryable();
            }
            
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

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Sprint>> GetSprints(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Sprints.AsQueryable();
        }


        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Epic>> GetEpics(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Epics.AsQueryable();
        }


        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Comment>> GetComments(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Comments.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Tag>> GetTags(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Tags.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Storypoint>> GetStorypoints(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Storypoints.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Boardtask>> GetBoardTasks(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Boardtasks.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Boardcolumn>> GetBoardColumns(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Boardcolumns.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Sprinttask>> GetSprintTasks(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Sprinttasks.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Taskitemepic>> GetTaskitemEpics(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Taskitemepics.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Priority>> GetPriorities(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Priorities.AsQueryable();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Category>> GetCategories(
            [Service] IDbContextFactory<AppDbContext> dbContextFactory)
        {
            var db = await dbContextFactory.CreateDbContextAsync();
            return db.Categories.AsQueryable();
        }
    }
}
