using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Infrastructure.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> modelBuilder)
        {
            modelBuilder.Property(c => c.Name)
                .HasColumnType("nvarchar(40)")
                .IsRequired();

            modelBuilder.Property(c => c.CreationTime)
                .HasDefaultValueSql("GetDate()");



        }
    }
}
