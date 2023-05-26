using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlDemo.Bussiness_Models;

namespace MySqlDemo.ViewModel
{
    public class EmployeeViewModel
    {
        public string SearchText { get; set; }
        public List<EmployeeModel> List { get; set; }
        public EmployeeModel EmployeeModel { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
    }
}
