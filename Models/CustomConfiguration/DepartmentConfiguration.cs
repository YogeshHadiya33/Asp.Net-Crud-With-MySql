using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MySqlDemo.Models.CustomConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(d => d.DepartmentId);

            builder.HasIndex(x => x.DepartmentCode).HasDatabaseName("IDX_Department_DepartmentCode");
            builder.HasIndex(x => x.DepartmentName).HasDatabaseName("IDX_Department_DepartmentName");
       
            builder.Property(x => x.DepartmentCode).HasMaxLength(15);
            builder.Property(x => x.DepartmentName).HasMaxLength(100);

        }
    }
}
