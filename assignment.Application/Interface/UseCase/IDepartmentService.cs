namespace assignment.Application.Interface.UseCase
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Application.DTOs.Request;
    using assignment.Domain.Entities;

    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department> AddDepartmentAsync(DepartmentRequest department);
        Task<Department> UpdateDepartmentAsync(int id, DepartmentRequest department);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}