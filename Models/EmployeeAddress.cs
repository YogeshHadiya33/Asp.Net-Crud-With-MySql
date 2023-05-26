using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySqlDemo.Models
{
    
    public class EmployeeAddress
    {
    
        public int EmployeeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string Zipcode { get; set; }
    
        public Employee Employee { get; set; }
    }
}
