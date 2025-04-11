using assignment.Application.Interface.Gateway;
using assignment.Domain.Entities;
using assignment.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace assignment.Infrastructure.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        public ApplicationDbContext _context;
        public ProjectRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Project> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project?> GetProjectById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            var existingProject = await _context.Projects.FindAsync(project.Id);
            if (existingProject == null)
            {
                throw new KeyNotFoundException("Project not found");
            }

            existingProject = project;

            await _context.SaveChangesAsync();
            return existingProject;
        }
    }
}