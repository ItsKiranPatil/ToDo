using Microsoft.EntityFrameworkCore;
using ToDoDemo.Models;

namespace ToDoDemo.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; } = null!;
        public DbSet<Category> Categorys { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        //Seed Data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryID = 1, Name = "Work" },
                    new Category { CategoryID = 2, Name = "Home" },
                    new Category { CategoryID = 3, Name = "Exercise" },
                    new Category { CategoryID = 4, Name = "Shopping" },
                    new Category { CategoryID = 5, Name = "Contact" },
                    new Category { CategoryID = 6, Name = "Other" }

                );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusID = 1, Name = "Open" },
                new Status { StatusID = 2, Name = "Active" },
                new Status { StatusID = 3, Name = "Completed" });
        }
    }
}
