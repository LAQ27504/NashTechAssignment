using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface IEmployeeRepo
    {
        Task<Employee?> GetEmployeeById(int id);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);

        Task<List<EmployeeWithDepartmentDTO>> GetAllEmployeeAndDepartmentAsync();
        Task<List<EmployeeWithProjectDTO>> GetAllEmployeeAndProjectAsync();
        Task<List<Employee>> GetHighSalaryEmployeesAsync();
    }
}