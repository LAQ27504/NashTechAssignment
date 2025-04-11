namespace assignment.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
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

        public async Task<ProjectEmployee> GetProjectEmployeeByProjectID(int projectId)
        {
            var projectEmployee = await _context.ProjectEmployees.FindAsync(projectId);
            if (projectEmployee == null)
            {
                throw new KeyNotFoundException("ProjectEmployee not found");
            }
            return projectEmployee;
        }
    }
}