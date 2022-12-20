using System;
using Linky.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Linky.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Campus> Campuses { get; set; }

        public DbSet<Course> Courses { get; set; }
    
        public DbSet<Group> Groups { get; set; }
    
        public DbSet<Room> Rooms { get; set; }
        
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Worker> Workers { get; set; }
        
        public DbSet<CourseMessage> CourseMessages { get; set; }
        
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campus>()
                .HasMany(s => s.Workers)
                .WithOne(c => c.Campus)
                .HasForeignKey(p => p.Id);
            
            modelBuilder.Entity<Campus>()
                .HasMany(s => s.Students)
                .WithOne(c => c.Campus)
                .HasForeignKey(p => p.Id);
            
            modelBuilder.Entity<Campus>()
                .HasMany(s => s.Rooms)
                .WithOne(c => c.Campus)
                .HasForeignKey(p => p.Id);

            modelBuilder.Entity<Student>()
                .HasOne(r => r.Group)
                .WithMany(c => c.Students)
                .HasForeignKey(p => p.Id);
            
            modelBuilder.Entity<CourseMessage>()
                .HasOne(r => r.Course)
                .WithMany(c => c.CourseMessages)
                .HasForeignKey(p => p.Id);
        }
    }
}