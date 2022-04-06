using Microsoft.EntityFrameworkCore;
using CrudOperations.Models;

namespace CrudOperations.Models.Database
{
    public class DatabaseModel:DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        public DatabaseModel(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Course>().HasKey(c => new { c.StudentId , c.CourseId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CrudOperations.Models.Student_Course> Student_Course { get; set; }
    }
}
