namespace assignment.Application.Interface.UseCase
{
    using assignment.Domain.Entities;
    public interface IProjectService
    {
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<List<Project>> GetAllProjectsAsync();
    }
}