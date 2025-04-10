namespace assignment.Application.Interface.UseCase
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Domain.Entities;

    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}