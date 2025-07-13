using Microsoft.EntityFrameworkCore;
using ProjectAndTaskManagement.Data;
using ProjectAndTaskManagement.GraphQL;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Hot Chocolate GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    var context = await dbFactory.CreateDbContextAsync();
    await SeedData.SeedAsync(context);
}


app.MapGraphQL();

app.Run();
