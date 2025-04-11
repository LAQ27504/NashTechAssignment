using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface IDepartmentRepo
    {
        Task<List<Department>> GetAllDepartmentsAsync();

        Task<Department?> GetDepartmentByIdAsync(int id);

        Task<Department> AddDepartmentAsync(Department department);

        Task<Department> UpdateDepartmentAsync(int id, Department department);

        Task<bool> DeleteDepartmentAsync(int id);
    }
}