using assignment.Application.Interface.Gateway;
using assignment.Application.Interface.UseCase;
using assignment.Domain.Entities;

namespace assignment.Application.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            return await _departmentRepo.AddDepartmentAsync(department);
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            return await _departmentRepo.DeleteDepartmentAsync(id);
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepo.GetAllDepartmentsAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepo.GetDepartmentByIdAsync(id);
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            return await _departmentRepo.UpdateDepartmentAsync(department);
        }
    }
}