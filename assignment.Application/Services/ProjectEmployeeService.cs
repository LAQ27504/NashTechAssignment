namespace assignment.Application.Services
{
    using assignment.Application.Interface.Gateway;
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;

    public class ProjectEmployeeService : IProjectEmployeeService
    {
        private readonly IProjectEmployeeRepo _projectEmployeeRepo;

        public ProjectEmployeeService(IProjectEmployeeRepo projectEmployeeRepo)
        {
            _projectEmployeeRepo = projectEmployeeRepo;
        }

        public async Task<ProjectEmployee> GetProjectEmployeeByIdAsync(int id)
        {
            return await _projectEmployeeRepo.GetProjectEmployeeByProjectID(id);
        }
    }
}