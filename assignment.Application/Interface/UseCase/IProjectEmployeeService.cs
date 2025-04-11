namespace assignment.Application.Interface.UseCase
{
    using assignment.Application.DTOs.Request;
    using assignment.Domain.Entities;
    public interface IProjectEmployeeService
    {
        Task<ProjectEmployee> GetProjectEmployeeByProjectID(int projectId);
        Task<List<ProjectEmployee>> GetAllProjectEmployees();
        Task<ProjectEmployee> AddProjectEmployee(ProjectEmployeeRequest ProjectEmployee);
        Task<bool> DeletProjectEmployee(ProjectEmployeeRequest ProjectEmployee);
    }
}