using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MySqlDemo.Bussiness_Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        
        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Please specify Department Name")]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        [DisplayName("Department Code")]
        [Required(ErrorMessage = "Please specify Department Code")]
        [MaxLength(15)]
        public string DepartmentCode { get; set; }

    }
}
