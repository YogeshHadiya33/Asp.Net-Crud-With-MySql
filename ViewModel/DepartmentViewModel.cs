using MySqlDemo.Bussiness_Models;

namespace MySqlDemo.ViewModel
{
    public class DepartmentViewModel
    {
        public string SearchText { get; set; }
        public List<DepartmentModel> List { get; set; }
    }
}
