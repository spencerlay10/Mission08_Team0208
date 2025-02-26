using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0208.Models
{
    // Allows for the creation of a database context
    public class QuadrantContext : DbContext // Liaison from the app to the database
    {
        public QuadrantContext(DbContextOptions<QuadrantContext> options) : base(options) // Constructor
        {
        }

        // Tasks table is created with the Task model
        public DbSet<Task> Tasks { get; set; }
        // Categories table is created with the Category model
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }

                );
        }
    }
}
