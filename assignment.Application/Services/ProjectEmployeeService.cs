namespace assignment.Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Application.DTOs.Request;
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

        public async Task<ProjectEmployee> AddProjectEmployee(ProjectEmployeeRequest projectEmployeeRequest)
        {
            var projectEmployee = new ProjectEmployee
            {
                ProjectId = projectEmployeeRequest.ProjectId,
                EmployeeId = projectEmployeeRequest.EmployeeId,
            };

            await _projectEmployeeRepo.AddProjectEmployee(projectEmployee);
            return projectEmployee;
        }

        public async Task<bool> DeletProjectEmployee(ProjectEmployeeRequest projectEmployeeRequest)
        {
            await _projectEmployeeRepo.DeletProjectEmployee(projectEmployeeRequest);
            return true;
        }

        public async Task<List<ProjectEmployee>> GetAllProjectEmployees()
        {
            return await _projectEmployeeRepo.GetAllProjectEmployees();
        }


        public async Task<ProjectEmployee> GetProjectEmployeeByProjectID(int projectId)
        {
            return await _projectEmployeeRepo.GetProjectEmployeeByProjectID(projectId);
        }
    }
}