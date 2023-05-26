using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MySqlDemo.Bussiness_Models
{
    public class EmployeeAddressModel
    {
        [DisplayName("Address Line 1")]
        [Required(ErrorMessage = "Please specify Address Line 1")]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")] 
        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please specify City")]
        [MaxLength(50)]
        public string City { get; set; }

        [DisplayName("State Name")]
        [Required(ErrorMessage = "Please specify State Name")]
        [MaxLength(50)]
        public string StateName { get; set; }

        [DisplayName("Zipcode")]
        [Required(ErrorMessage = "Please specify Zipcode")]
        [MaxLength(10)]
        public string Zipcode { get; set; }
    }
}
