namespace assignment.Application.Interface.UseCase
{
    using assignment.Domain.Entities;
    public interface IEmployeeService
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<List<EmployeeWithDepartmentDTO>> GetAllEmployeeAndDepartmentAsync();
        Task<List<EmployeeWithProjectDTO>> GetAllEmployeeAndProjects();
        Task<List<Employee>> GetHighSalaryEmployeesAsync();
    }
}