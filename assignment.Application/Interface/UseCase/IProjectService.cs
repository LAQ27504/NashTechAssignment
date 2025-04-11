namespace assignment.Application.Interface.UseCase
{
    using assignment.Application.DTOs.Request;
    using assignment.Domain.Entities;
    public interface IProjectService
    {
        Task<Project> AddProjectAsync(ProjectRequest project);
        Task<Project> UpdateProjectAsync(int id, ProjectRequest project);
        Task<bool> DeleteProjectAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<List<Project>> GetAllProjectsAsync();
    }
}