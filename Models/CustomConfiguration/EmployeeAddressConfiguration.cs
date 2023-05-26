using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MySqlDemo.Models.CustomConfiguration
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.ToTable("EmployeeAddress");
            builder.HasKey(x => x.EmployeeId);

            builder.HasIndex(x => x.AddressLine1).HasDatabaseName("IDX_EmployeeAddress_AddressLine1");
            builder.HasIndex(x => x.AddressLine2).HasDatabaseName("IDX_EmployeeAddress_AddressLine2");
            builder.HasIndex(x => x.StateName).HasDatabaseName("IDX_EmployeeAddress_StateName");
            builder.HasIndex(x => x.City).HasDatabaseName("IDX_EmployeeAddress_City");
            builder.HasIndex(x => x.Zipcode).HasDatabaseName("IDX_EmployeeAddress_Zipcode");

            builder.Property(x => x.AddressLine1).HasMaxLength(100);
            builder.Property(x => x.AddressLine2).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.StateName).HasMaxLength(50);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.Zipcode).HasMaxLength(10);

           


        }
    }
}
