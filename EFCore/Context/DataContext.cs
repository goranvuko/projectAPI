using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context
{
    public class DataContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyTask>()
                .Property(t => t.TaskStatus).HasConversion<string>(); // for taskStatus to appear as a string in a database
            
            modelBuilder.Entity<MyTask>()
                .Property(t => t.TaskStatus).HasDefaultValue(Core.Enums.TaskStatus.ToDo); // setting default value for field taskStatus

            modelBuilder.Entity<Project>()
                .Property(p => p.ProjectStatus).HasConversion<string>(); // for projectStatus to appear as a string in a database
   
            modelBuilder.Entity<Project>()
                .Property(p => p.ProjectStatus).HasDefaultValue(Core.Enums.ProjectStatus.NotStarted); // setting default value for field projectStatus

        }
    }
}