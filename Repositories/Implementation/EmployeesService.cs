using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models.Domain;
using ASPNETMVCCRUD.Repositories.Abstract;

namespace ASPNETMVCCRUD.Repositories.Implementation
{
    public class EmployeesService : IEmployeesService
    {
        private readonly MVCDemoDbContext _context;
        public EmployeesService(MVCDemoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<Employee> GetAll()
        {
            var list = _context.Employees.ToList();
            return list;
        }

        public Employee Get(Guid id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public bool Update(Employee employee)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Salary = employee.Salary;
                emp.DateOfBirth = employee.DateOfBirth;
                emp.Department = employee.Department;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Employee employee)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (emp != null)
            {
                _context.Remove(emp);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
