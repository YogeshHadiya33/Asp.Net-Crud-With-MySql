using Microsoft.EntityFrameworkCore;
using MySqlDemo.Models.CustomConfiguration;

namespace MySqlDemo.Models
{
    public class MySqlDemoContext : DbContext
    {
        public MySqlDemoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeAddressConfiguration());

        }
    }
}
