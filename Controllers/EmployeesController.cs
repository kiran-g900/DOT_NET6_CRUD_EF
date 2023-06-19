using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using ASPNETMVCCRUD.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService employeesService;
        public EmployeesController(IEmployeesService employeesService)
        {
              this.employeesService = employeesService;
        }        

        [HttpGet]
        public IActionResult Index()
        {
            var employees = employeesService.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department,
            };
            
            await employeesService.Add(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult View(Guid id)
        {
            var employee = employeesService.Get(id);
            return View("View", employee);
        }

        [HttpPost]
        public IActionResult View(Employee emp)
        {
            var isUpdated = employeesService.Update(emp);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            var isDeleted = employeesService.Delete(emp);
            if(isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View(emp);
        }
    }
}
