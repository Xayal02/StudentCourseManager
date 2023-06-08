using Microsoft.EntityFrameworkCore;
using StudentsCoursesManager.Data.Entities;
using System.Reflection;

namespace StudentsCoursesManager.Data.Common
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<StudentCourse> Genders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
