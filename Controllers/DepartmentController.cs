using Microsoft.AspNetCore.Mvc;
using MySqlDemo.Bussiness_Models;
using MySqlDemo.Models;
using MySqlDemo.ViewModel;

namespace MySqlDemo.Controllers
{
    public class DepartmentController : Controller
    {
        MySqlDemoContext _Context;
        public DepartmentController(MySqlDemoContext context)
        {
            _Context = context;
        }
        
        public IActionResult Index(string searchText = "")
        {
            searchText = searchText.Trim();
            DepartmentViewModel model = new DepartmentViewModel() { SearchText = searchText };
            try
            {
                var departments = _Context.Department.AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                    departments = departments.Where(x => x.DepartmentName.ToLower().Contains(searchText.ToLower()) || x.DepartmentCode.ToLower().Contains(searchText.ToLower()));

                model.List = departments.Select(x => new DepartmentModel()
                {
                    DepartmentName = x.DepartmentName,
                    DepartmentId = x.DepartmentId,
                    DepartmentCode = x.DepartmentCode,
                }).ToList();
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = null;
                TempData["ErrorMessage"] = "Something went wrong. Please try again later";
            }

            return View(model);
        }

        public IActionResult Add(int id = 0)
        {
            DepartmentModel model = new DepartmentModel();
            try
            {
                var department = _Context.Department.FirstOrDefault(x => x.DepartmentId == id);
                if (department != null)
                {
                    model.DepartmentCode = department.DepartmentCode;
                    model.DepartmentName = department.DepartmentName;
                    model.DepartmentId = department.DepartmentId;
                }
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = null;
                TempData["ErrorMessage"] = "Something went wrong. Please try again later";
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(DepartmentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _temp = _Context.Department.FirstOrDefault(x => x.DepartmentId == model.DepartmentId);

                    if (_Context.Department.Any(x => x.DepartmentCode.ToLower() == model.DepartmentCode.ToLower() && x.DepartmentId != model.DepartmentId))
                    {
                        TempData["ErrorMessage"] = "Deppartment already exists with this department code";
                    }
                    else if (_Context.Department.Any(x => x.DepartmentName.ToLower() == model.DepartmentName.ToLower() && x.DepartmentId != model.DepartmentId))
                    {
                        TempData["ErrorMessage"] = "Deppartment already exists with this department name";
                    }
                    else
                    {
                        Department department = _temp != null ? _temp : new Department();

                        department.DepartmentName = model.DepartmentName;
                        department.DepartmentCode = model.DepartmentCode;

                        if (_temp == null)
                        {
                            _Context.Department.Add(department);
                            TempData["SuccessMessage"] = "Department added successfully";
                        }
                        else
                        {
                            _Context.Department.Update(department);
                            TempData["SuccessMessage"] = "Department updated successfully";
                        }
                        _Context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = null;
                TempData["ErrorMessage"] = "Something went wrong. Please try again later";
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var department = _Context.Department.FirstOrDefault(x => x.DepartmentId == id);
                    if (department != null)
                    {
                        _Context.Department.Remove(department);
                        _Context.SaveChanges();
                        TempData["SuccessMessage"] = "Department deleted successfully";
                    }
                    else
                        TempData["ErrorMessage"] = "Department not found with this id: " + id;
                }
                else
                    TempData["ErrorMessage"] = "Department Id must be greater than 0";
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = null;
                TempData["ErrorMessage"] = "Something went wrong. Please try again later";
            }
            return RedirectToAction("Index");
        }

    }
}
