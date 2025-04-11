using assignment.Application.DTOs.Request;
using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface IProjectEmployeeRepo
    {
        Task<ProjectEmployee> GetProjectEmployeeByProjectID(int projectId);
        Task<List<ProjectEmployee>> GetAllProjectEmployees();

        Task<ProjectEmployee> AddProjectEmployee(ProjectEmployee ProjectEmployee);
        Task<bool> DeletProjectEmployee(ProjectEmployeeRequest ProjectEmployee);

    }
}