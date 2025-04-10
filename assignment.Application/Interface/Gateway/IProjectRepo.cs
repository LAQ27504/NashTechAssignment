using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface IProjectRepo
    {
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(Project project);
        Task<bool> DeleteProject(int id);
        Task<Project?> GetProjectById(int id);
        Task<List<Project>> GetAllProjects();
        Task<List<Project>> GetProjectsByEmployeeId(int employeeId);
    }
}