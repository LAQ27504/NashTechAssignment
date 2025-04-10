namespace assignment.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using assignment.Application.Interface.Gateway;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Persistence.DBContext;
    using Microsoft.EntityFrameworkCore;

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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public Task<Department?> GetDepartmentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> UpdateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}