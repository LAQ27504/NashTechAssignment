using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface IProjectEmployeeRepo
    {
        Task<ProjectEmployee> GetProjectEmployeeByProjectID(int projectId);
        Task<List<ProjectEmployee>> GetAllProjectEmployees();

        Task<ProjectEmployee> AddProjectEmployee(ProjectEmployee projectEmployee);
        Task<ProjectEmployee> UpdateProjectEmployee(int id, ProjectEmployee projectEmployee);
        Task<bool> DeleteProjectEmployeeByEmployeeId(int employeeId);
        Task<bool> DeleteProjectEmployeeByProjectId(int projectId);
    }
}