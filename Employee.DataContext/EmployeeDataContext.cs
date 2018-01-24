using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.DataContext
{
    public class EmployeeDataContext : DbContext
    {
        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        // Employee Fluent Api
            var employee = modelBuilder.Entity<Models.Employee>();

            employee
                .HasKey(s => s.Id)
                .HasAnnotation("Unique", true);

            employee
                .HasMany(c => c.Skills)
                .WithOne(s => s.Employee)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            employee
                .HasIndex(e => new { e.FirstName, e.LastName})
                .IsUnique();
            employee
                .HasIndex(e => new {e.Email})
                .IsUnique();

            employee
                .Property(p => p.FirstName)
                .HasMaxLength(128)
                .IsRequired();

            employee
                .Property(s => s.LastName)
                .HasMaxLength(128)
                .IsRequired();

            employee
                .Property(s => s.Email)
                .IsRequired();
            
         // Skill fluent Api

            var skill = modelBuilder.Entity<Skill>();

            skill
                .HasKey(s => s.Id)
                .HasAnnotation("Unique", true);

            skill
                .HasOne(e => e.Employee)
                .WithMany(s => s.Skills)
                .HasForeignKey(s => s.EmployeeId);

            skill
                .Property(n => n.Name)
                .HasMaxLength(56)
                .IsRequired();
        }
    }
}
