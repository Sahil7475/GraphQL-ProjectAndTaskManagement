using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectAndTaskManagement.Models;
using Tag = ProjectAndTaskManagement.Models.Tag;

namespace ProjectAndTaskManagement.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boardcolumn> Boardcolumns { get; set; }

    public virtual DbSet<Boardtask> Boardtasks { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Epic> Epics { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Projectboard> Projectboards { get; set; }

    public virtual DbSet<Sprint> Sprints { get; set; }

    public virtual DbSet<Sprinttask> Sprinttasks { get; set; }

    public virtual DbSet<Storypoint> Storypoints { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TaskItem> TaskItems { get; set; }

    public virtual DbSet<Taskitemepic> Taskitemepics { get; set; }

    public virtual DbSet<User> Users { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boardcolumn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("boardcolumns_pkey");

            entity.ToTable("boardcolumns");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Boardid).HasColumnName("boardid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Orderindex).HasColumnName("orderindex");

            entity.HasOne(d => d.Board).WithMany(p => p.Boardcolumns)
                .HasForeignKey(d => d.Boardid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("boardcolumns_boardid_fkey");
        });

        modelBuilder.Entity<Boardtask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("boardtasks_pkey");

            entity.ToTable("boardtasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Columnid).HasColumnName("columnid");
            entity.Property(e => e.Movedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("movedat");
            entity.Property(e => e.Taskitemid).HasColumnName("taskitemid");

            entity.HasOne(d => d.Column).WithMany(p => p.Boardtasks)
                .HasForeignKey(d => d.Columnid)
                .HasConstraintName("boardtasks_columnid_fkey");

            entity.HasOne(d => d.Taskitem).WithMany(p => p.Boardtasks)
                .HasForeignKey(d => d.Taskitemid)
                .HasConstraintName("boardtasks_taskitemid_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Comments_pkey");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Comments_AuthorId_fkey");

            entity.HasOne(d => d.TaskItem).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TaskItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Comments_TaskItemId_fkey");
        });

        modelBuilder.Entity<Epic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("epics_pkey");

            entity.ToTable("epics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Project).WithMany(p => p.Epics)
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("epics_projectid_fkey");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Priorities_pkey");

            entity.HasIndex(e => e.Level, "Priorities_Level_key").IsUnique();
        });

        modelBuilder.Entity<Projectboard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projectboards_pkey");

            entity.ToTable("projectboards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Projectid).HasColumnName("projectid");

            entity.HasOne(d => d.Project).WithMany(p => p.Projectboards)
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("projectboards_projectid_fkey");
        });

        modelBuilder.Entity<Sprint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sprints_pkey");

            entity.ToTable("sprints");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Startdate).HasColumnName("startdate");

            entity.HasOne(d => d.Project).WithMany(p => p.Sprints)
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sprints_projectid_fkey");
        });

        modelBuilder.Entity<Sprinttask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sprinttasks_pkey");

            entity.ToTable("sprinttasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sprintid).HasColumnName("sprintid");
            entity.Property(e => e.Taskitemid).HasColumnName("taskitemid");

            entity.HasOne(d => d.Sprint).WithMany(p => p.Sprinttasks)
                .HasForeignKey(d => d.Sprintid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sprinttasks_sprintid_fkey");

            entity.HasOne(d => d.Taskitem).WithMany(p => p.Sprinttasks)
                .HasForeignKey(d => d.Taskitemid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sprinttasks_taskitemid_fkey");
        });

        modelBuilder.Entity<Storypoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("storypoints_pkey");

            entity.ToTable("storypoints");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Taskitemid).HasColumnName("taskitemid");

            entity.HasOne(d => d.Taskitem).WithMany(p => p.Storypoints)
                .HasForeignKey(d => d.Taskitemid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("storypoints_taskitemid_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tags_pkey");

            entity.HasIndex(e => e.Name, "Tags_Name_key").IsUnique();
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasIndex(e => e.AssigneeId, "IX_TaskItems_AssigneeId");

            entity.HasIndex(e => e.ProjectId, "IX_TaskItems_ProjectId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Assignee).WithMany(p => p.TaskItemAssignees).HasForeignKey(d => d.AssigneeId);

            entity.HasOne(d => d.Category).WithMany(p => p.TaskItems)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_taskitems_categoryid");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TaskItemCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("TaskItems_CreatedBy_fkey");

            entity.HasOne(d => d.ParentTask).WithMany(p => p.InverseParentTask)
                .HasForeignKey(d => d.ParentTaskId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TaskItems_ParentTaskId_fkey");

            entity.HasOne(d => d.Priority).WithMany(p => p.TaskItems)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("TaskItems_PriorityId_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.TaskItems).HasForeignKey(d => d.ProjectId);

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TaskItemUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("TaskItems_UpdatedBy_fkey");

            entity.HasMany(d => d.Tags).WithMany(p => p.TaskItems)
                .UsingEntity<Dictionary<string, object>>(
                    "TaskItemTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("TaskItemTags_TagId_fkey"),
                    l => l.HasOne<TaskItem>().WithMany()
                        .HasForeignKey("TaskItemId")
                        .HasConstraintName("TaskItemTags_TaskItemId_fkey"),
                    j =>
                    {
                        j.HasKey("TaskItemId", "TagId").HasName("TaskItemTags_pkey");
                        j.ToTable("TaskItemTags");
                    });

            entity.HasMany(d => d.Users).WithMany(p => p.TaskItems)
                .UsingEntity<Dictionary<string, object>>(
                    "TaskWatcher",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("TaskWatchers_UserId_fkey"),
                    l => l.HasOne<TaskItem>().WithMany()
                        .HasForeignKey("TaskItemId")
                        .HasConstraintName("TaskWatchers_TaskItemId_fkey"),
                    j =>
                    {
                        j.HasKey("TaskItemId", "UserId").HasName("TaskWatchers_pkey");
                        j.ToTable("TaskWatchers");
                    });
        });

        modelBuilder.Entity<Taskitemepic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("taskitemepics_pkey");

            entity.ToTable("taskitemepics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Epicid).HasColumnName("epicid");
            entity.Property(e => e.Taskitemid).HasColumnName("taskitemid");

            entity.HasOne(d => d.Epic).WithMany(p => p.Taskitemepics)
                .HasForeignKey(d => d.Epicid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("taskitemepics_epicid_fkey");

            entity.HasOne(d => d.Taskitem).WithMany(p => p.Taskitemepics)
                .HasForeignKey(d => d.Taskitemid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("taskitemepics_taskitemid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
