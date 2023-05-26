using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MySqlDemo.Bussiness_Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
       
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please specify First Name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please specify Last Name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "Please specify Date Of Birth")]
        [DataType(DataType.Date,ErrorMessage ="Please enter valid date")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Salary")]
        [Required(ErrorMessage = "Please specify Salary")]
        public decimal Salary { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please specify Email Address")]
        [MaxLength(200)]
        public string EmailAddress { get; set; }


        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Please specify Phone Number")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Please select Department")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Department")]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public EmployeeAddressModel EmployeeAddressModel { get; set; }
    }

}
