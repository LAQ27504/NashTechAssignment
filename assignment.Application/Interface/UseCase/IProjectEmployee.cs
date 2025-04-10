namespace assignment.Application.Interface.UseCase
{
    using assignment.Domain.Entities;
    public interface IProjectEmployee
    {
        Task<ProjectEmployee> AddProjectEmployeeAsync(ProjectEmployee projectEmployee);
        Task<ProjectEmployee> UpdateProjectEmployeeAsync(ProjectEmployee projectEmployee);
        Task<bool> DeleteProjectEmployeeAsync(int id);
        Task<ProjectEmployee> GetProjectEmployeeByIdAsync(int id);
        Task<IEnumerable<ProjectEmployee>> GetAllProjectEmployeesAsync();
    }
}