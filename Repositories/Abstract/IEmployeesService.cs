using ASPNETMVCCRUD.Models.Domain;

namespace ASPNETMVCCRUD.Repositories.Abstract
{
    public interface IEmployeesService
    {
        Task<bool> Add(Employee employee);
        List<Employee> GetAll();
        Employee Get(Guid id);
        bool Update(Employee employee);
        bool Delete(Employee employee);
    } 
}
