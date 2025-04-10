using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();

        Task<Department?> GetDepartmentByIdAsync(int id);

        Task<Department> AddDepartmentAsync(Department department);

        Task<Department> UpdateDepartmentAsync(Department department);

        Task<bool> DeleteDepartmentAsync(int id);
    }
}