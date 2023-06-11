using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Infrastructure.EntityConfigurations
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> modelBuilder)
        {
            modelBuilder.HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .HasConstraintName("FK_Student");

            modelBuilder.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsCourses)
                .HasForeignKey(sc => sc.CourseId)
                .HasConstraintName("FK_Course");

            modelBuilder.HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
