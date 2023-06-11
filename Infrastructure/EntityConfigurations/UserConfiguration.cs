using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Infrastructure.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.Property(u => u.UserName)
                        .IsRequired();

            modelBuilder.Property(u => u.Password)
                       .IsRequired();

            modelBuilder.Property(u => u.Email)
                        .IsRequired();



            modelBuilder.Property(u => u.FirstName)
                        .HasMaxLength(15)
                        .IsRequired();

            modelBuilder.Property(u => u.LastName)
                        .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Property(u => u.Role)
                        .IsRequired();

            modelBuilder.Property(u => u.DateOfBirth)
                       .HasColumnType("Date")
                       .IsRequired();

            modelBuilder.Ignore(u => u.Age);

            modelBuilder.HasIndex(u => u.UserName)
                        .IsUnique()
                        .HasDatabaseName("IX_Username");

            modelBuilder.HasIndex(u => u.Email)
                       .IsUnique()
                       .HasDatabaseName("IX_Email");
        }
    }
}
