namespace assignment.Application.Services
{
    using assignment.Application.DTOs.Request;
    using assignment.Application.Interface.Gateway;
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _projectRepo;

        public ProjectService(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<Project> AddProjectAsync(ProjectRequest project)
        {
            Project newProject = new Project
            {
                Id = project.Id,
                Name = project.Name,
            };
            return await _projectRepo.AddProject(newProject);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _projectRepo.DeleteProject(id);
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _projectRepo.GetAllProjects();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepo.GetProjectById(id);
        }

        public async Task<Project> UpdateProjectAsync(ProjectRequest project)
        {
            Project updateProject = new Project
            {
                Id = project.Id,
                Name = project.Name,
            };
            return await _projectRepo.UpdateProject(updateProject);
        }
    }
}