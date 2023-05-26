using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MySqlDemo.Models.CustomConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(x => x.EmployeeId);

            builder.HasIndex(x => x.FirstName).HasDatabaseName("IDX_Employee_FirstName");
            builder.HasIndex(x => x.LastName).HasDatabaseName("IDX_Employee_LastName");
            builder.HasIndex(x => x.DateOfBirth).HasDatabaseName("IDX_Employee_DateOfBirth");
            builder.HasIndex(x => x.Salary).HasDatabaseName("IDX_Employee_Salary");
            builder.HasIndex(x => x.EmailAddress).HasDatabaseName("IDX_Employee_EmailAddress");
            builder.HasIndex(x => x.PhoneNumber).HasDatabaseName("IDX_Employee_PhoneNumber");

            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.EmailAddress).HasMaxLength(200);
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employee)
                .HasForeignKey(x => x.DepartmentId)
                .HasConstraintName("FK_Department_Employee_DepartmentId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.EmployeeAddress)
               .WithOne(x => x.Employee)
               .HasForeignKey<EmployeeAddress>(x => x.EmployeeId)
               .HasConstraintName("FK_EmployeeAddress_Employee_EmployeeId")
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
