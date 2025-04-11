namespace assignment.Application.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Application.Interface.Gateway;
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {

            return await _employeeRepo.AddEmployee(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepo.DeleteEmployee(id);
        }

        public async Task<List<EmployeeWithDepartmentDTO>> GetAllEmployeeAndDepartmentAsync()
        {
            return await _employeeRepo.GetAllEmployeeAndDepartmentAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepo.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepo.GetEmployeeById(id);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            return await _employeeRepo.UpdateEmployee(employee);
        }

        public async Task<List<EmployeeWithProjectDTO>> GetAllEmployeeAndProjects()
        {
            return await _employeeRepo.GetAllEmployeeAndProjectAsync();
        }

        public async Task<List<Employee>> GetHighSalaryEmployeesAsync()
        {
            return await _employeeRepo.GetHighSalaryEmployeesAsync();
        }
    }
}