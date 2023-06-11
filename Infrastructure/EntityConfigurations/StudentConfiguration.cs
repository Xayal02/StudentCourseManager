using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Infrastructure.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> modelBuilder)
        {
            modelBuilder.Property(s => s.FirstName)
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            modelBuilder.Property(s => s.LastName)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            modelBuilder.Property(s => s.DateOfBirth)
                .HasColumnType("Date")
                .IsRequired();

            modelBuilder.Property(s => s.Email)
                 .HasColumnType("nvarchar(50)");

            modelBuilder.HasIndex(s => s.Email).
                IsUnique().
                HasDatabaseName("IX_Email");

            modelBuilder.HasOne(s => s.Gender).WithMany(g => g.Students).HasForeignKey(s => s.GenderId).HasConstraintName("FK_Gender");


        }
    }
}
