using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface IProjectEmployeeRepo
    {
        Task<ProjectEmployee> AddProjectEmployee(int projectId, int employeeId);
        Task<bool> RemoveProjectEmployee(int projectId, int employeeId);
        Task<ProjectEmployee> UpdateProjectEmployee(int projectId, int employeeId, bool enable);
        Task<List<ProjectEmployee>> GetProjectEmployeeByProjectID(int projectId);
        Task<List<ProjectEmployee>> GetProjectEmployeeByEmployeeId(int employeeId);
        Task<List<ProjectEmployee>> GetAllProjectEmployees();
    }
}