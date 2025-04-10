using System.Collections.Generic;
using assignment.Application.Interface.Gateway;
using assignment.Domain.Entities;
using assignment.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace assignment.Infrastructure.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            var result = await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChangesAsync();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<Department>> GetAllDepartmentsAsync()
        {
            return _context.Departments
                .ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            var updateDepartment = await _context.Departments.FindAsync(department.Id);
            if (updateDepartment == null)
            {
                throw new Exception("Department not found");
            }
            updateDepartment = department;
            await _context.SaveChangesAsync();
            return updateDepartment;
        }
    }
}