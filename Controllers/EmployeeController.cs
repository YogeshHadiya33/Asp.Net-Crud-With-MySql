using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySqlDemo.Bussiness_Models;
using MySqlDemo.Models;
using MySqlDemo.ViewModel;
using System.Net.Mail;

namespace MySqlDemo.Controllers
{
    public class EmployeeController : Controller
    {
        MySqlDemoContext _Context;
        public EmployeeController(MySqlDemoContext context)
        {
            _Context = context;
        }

        public IActionResult Index(string searchText = "")
        {
            searchText = searchText.Trim();
            EmployeeViewModel model = new EmployeeViewModel() { SearchText = searchText };
            try
            {
                var employees = (from emp in _Context.Employees
                                 join dep in _Context.Department
                                 on emp.DepartmentId equals dep.DepartmentId
                                 select new { emp, dep }
                           ).AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                {
                    employees = employees.Where(x =>
                       x.emp.FirstName.ToLower().Contains(searchText.ToLower())
                    || x.emp.LastName.ToLower().Contains(searchText.ToLower())
                    || x.emp.EmailAddress.ToLower().Contains(searchText.ToLower())
                    || x.emp.PhoneNumber.ToLower().Contains(searchText.ToLower())
                    || x.dep.DepartmentName.ToLower().Contains(searchText.ToLower())
                    || x.emp.Salary.ToString().ToLower().Contains(searchText.ToLower())
                    );
                }

                model.List = employees.Select(x => new EmployeeModel()
                {
                    Salary = x.emp.Salary,
                    PhoneNumber = x.emp.PhoneNumber,
                    EmailAddress = x.emp.EmailAddress,
                    LastName = x.emp.LastName,
                    FirstName = x.emp.FirstName,
                    DateOfBirth = x.emp.DateOfBirth,
                    DepartmentId = x.emp.DepartmentId,
                    EmployeeId = x.emp.EmployeeId,
                    DepartmentName = x.dep.DepartmentName
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
            EmployeeViewModel model = new EmployeeViewModel()
            {
                DepartmentList = GetDepartmentList(),
                EmployeeModel = new EmployeeModel
                {
                    EmployeeId = 0,
                    EmployeeAddressModel = new EmployeeAddressModel(),
                }
            };
            try
            {
                var Employee = _Context.Employees.Include(x => x.EmployeeAddress).FirstOrDefault(x => x.EmployeeId == id);
                if (Employee != null)
                {
                    model.EmployeeModel.Salary = Employee.Salary;
                    model.EmployeeModel.PhoneNumber = Employee.PhoneNumber;
                    model.EmployeeModel.EmailAddress = Employee.EmailAddress;
                    model.EmployeeModel.LastName = Employee.LastName;
                    model.EmployeeModel.FirstName = Employee.FirstName;
                    model.EmployeeModel.DateOfBirth = Employee.DateOfBirth;
                    model.EmployeeModel.DepartmentId = Employee.DepartmentId;
                    model.EmployeeModel.EmployeeId = Employee.EmployeeId;

                    if (Employee.EmployeeAddress != null)
                    {
                        model.EmployeeModel.EmployeeAddressModel = new EmployeeAddressModel()
                        {
                            AddressLine1 = Employee.EmployeeAddress.AddressLine1,
                            AddressLine2 = Employee.EmployeeAddress.AddressLine2,
                            City = Employee.EmployeeAddress.City,
                            StateName = Employee.EmployeeAddress.StateName,
                            Zipcode = Employee.EmployeeAddress.Zipcode,
                        };
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

        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            try
            {

                model.DepartmentList = GetDepartmentList();

                if (ModelState.IsValid)
                {

                    var _temp = _Context.Employees.Include(x => x.EmployeeAddress).FirstOrDefault(x => x.EmployeeId == model.EmployeeModel.EmployeeId);

                    if (_Context.Employees.Any(x => x.FirstName.ToLower() == model.EmployeeModel.FirstName.ToLower() && x.LastName.ToLower() == model.EmployeeModel.LastName.ToLower() && x.EmployeeId != model.EmployeeModel.EmployeeId))
                    {
                        TempData["ErrorMessage"] = "Employee already exists with this name";
                    }
                    else
                    {
                        Employee employee = _temp != null ? _temp : new Employee();

                        employee.FirstName = model.EmployeeModel.FirstName;
                        employee.LastName = model.EmployeeModel.LastName;
                        employee.PhoneNumber = model.EmployeeModel.PhoneNumber;
                        employee.DateOfBirth = Convert.ToDateTime(model.EmployeeModel.DateOfBirth);
                        employee.Salary = model.EmployeeModel.Salary;
                        employee.DepartmentId = model.EmployeeModel.DepartmentId;
                        employee.EmailAddress = model.EmployeeModel.EmailAddress;

                        if (employee.EmployeeAddress == null)
                            employee.EmployeeAddress = new EmployeeAddress();
                        employee.EmployeeAddress.AddressLine1 = model.EmployeeModel.EmployeeAddressModel.AddressLine1;
                        employee.EmployeeAddress.AddressLine2 = model.EmployeeModel.EmployeeAddressModel.AddressLine2;
                        employee.EmployeeAddress.City = model.EmployeeModel.EmployeeAddressModel.City;
                        employee.EmployeeAddress.Zipcode = model.EmployeeModel.EmployeeAddressModel.Zipcode;
                        employee.EmployeeAddress.StateName = model.EmployeeModel.EmployeeAddressModel.StateName;

                        if (_temp == null)
                        {
                            _Context.Employees.Add(employee);
                            TempData["SuccessMessage"] = "Employee added successfully";
                        }
                        else
                        {
                            _Context.Employees.Update(employee);
                            TempData["SuccessMessage"] = "Employee updated successfully";
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
                    var employee = _Context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                    if (employee != null)
                    {
                        _Context.Employees.Remove(employee);
                        _Context.SaveChanges();
                        TempData["SuccessMessage"] = "Employee deleted successfully";
                    }
                    else
                        TempData["ErrorMessage"] = "Employee not found with this id: " + id;
                }
                else
                    TempData["ErrorMessage"] = "Employee Id must be greater than 0";
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = null;
                TempData["ErrorMessage"] = "Something went wrong. Please try again later";
            }
            return RedirectToAction("Index");
        }


        public List<SelectListItem> GetDepartmentList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from d in _Context.Department
                        select new SelectListItem()
                        {
                            Text = d.DepartmentName,
                            Value = d.DepartmentId.ToString()
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
    }
}
