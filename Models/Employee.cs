using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySqlDemo.Models
{

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual EmployeeAddress EmployeeAddress { get; set; }
    }
}
