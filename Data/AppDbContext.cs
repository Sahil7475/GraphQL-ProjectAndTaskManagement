using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectAndTaskManagement.Models;

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

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TaskItem> TaskItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasIndex(e => e.AssigneeId, "IX_TaskItems_AssigneeId");

            entity.HasIndex(e => e.ProjectId, "IX_TaskItems_ProjectId");

            entity.HasOne(d => d.Assignee).WithMany(p => p.TaskItems).HasForeignKey(d => d.AssigneeId);

            entity.HasOne(d => d.Category).WithMany(p => p.TaskItems)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_taskitems_categoryid");

            entity.HasOne(d => d.Project).WithMany(p => p.TaskItems).HasForeignKey(d => d.ProjectId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
