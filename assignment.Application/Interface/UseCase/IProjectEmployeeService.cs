namespace assignment.Application.Interface.UseCase
{
    using assignment.Domain.Entities;
    public interface IProjectEmployeeService
    {
        Task<ProjectEmployee> GetProjectEmployeeByIdAsync(int id);
        Task<List<ProjectEmployee>> GetAllProjectEmployeesAsync();
    }
}