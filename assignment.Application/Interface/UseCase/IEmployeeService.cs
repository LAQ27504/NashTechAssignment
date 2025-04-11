namespace assignment.Application.Interface.UseCase
{
    using assignment.Application.DTOs.Request;
    using assignment.Application.DTOs.Response;
    using assignment.Domain.Entities;
    public interface IEmployeeService
    {
        Task<Employee> AddEmployeeAsync(EmployeeRequest employee);
        Task<Employee> UpdateEmployeeAsync(int id, EmployeeRequest employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<List<EmployeeWithDepartmentDTO>> GetAllEmployeeAndDepartmentAsync();
        Task<List<EmployeeWithProjectDTO>> GetAllEmployeeAndProjects();
        Task<List<EmployeeHighSalaryJoinDate>> GetHighSalaryEmployeesAsync();
    }
}