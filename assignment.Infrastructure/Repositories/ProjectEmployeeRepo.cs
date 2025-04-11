namespace assignment.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Application.DTOs.Request;
    using assignment.Application.Interface.Gateway;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Persistence.DBContext;
    using Microsoft.EntityFrameworkCore;

    public class ProjectEmployeeRepo : IProjectEmployeeRepo
    {
        private readonly ApplicationDbContext _context;

        public ProjectEmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectEmployee> AddProjectEmployee(ProjectEmployee projectEmployee)
        {
            await _context.ProjectEmployees.AddAsync(projectEmployee);
            await _context.SaveChangesAsync();
            return projectEmployee;
        }

        public async Task<bool> DeletProjectEmployee(ProjectEmployeeRequest projectEmployee)
        {
            var existingEntity = await _context.ProjectEmployees
            .FirstOrDefaultAsync(pe => pe.EmployeeId == projectEmployee.EmployeeId && pe.ProjectId == projectEmployee.ProjectId);

            if (existingEntity == null)
            {
                return false;
            }

            _context.ProjectEmployees.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProjectEmployee>> GetAllProjectEmployees()
        {
            return await _context.ProjectEmployees.ToListAsync();
        }

        public async Task<ProjectEmployee> GetProjectEmployeeByProjectID(int projectId)
        {
            var projectEmployee = await _context.ProjectEmployees.FirstOrDefaultAsync(pe => pe.ProjectId == projectId);
            if (projectEmployee != null)
            {
                return projectEmployee;
            }
            return null;
        }
    }
}