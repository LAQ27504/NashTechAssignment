using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface IProjectEmployeeRepo
    {
        Task<ProjectEmployee> GetProjectEmployeeByProjectID(int projectId);
    }
}