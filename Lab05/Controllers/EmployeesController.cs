using Lab05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab05.Controllers
{
    public class EmployeesController : Controller
    {

        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, fullName = "Nguyen Van A", Gender = "Male", Phone = "0123456789", Email = "a@gmail.com", Salary = 1000, Status = "Active" },
            new Employee { Id = 2, fullName = "Tran Thi B", Gender = "Female", Phone = "0987654321", Email = "b@gmail.com", Salary = 1200, Status = "Inactive" }
        };

        public IActionResult Index()
        {
            return View(_employees);
        }

        public IActionResult Details(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (emp == null) return NotFound();

            emp.fullName = employee.fullName;
            emp.Gender = employee.Gender;
            emp.Phone = employee.Phone;
            emp.Email = employee.Email;
            emp.Salary = employee.Salary;
            emp.Status = employee.Status;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp != null) _employees.Remove(emp);
            return RedirectToAction(nameof(Index));
        }
    }
}
