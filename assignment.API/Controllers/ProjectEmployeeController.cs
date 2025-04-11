namespace assignment.API.Controllers
{
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeeController : ControllerBase
    {
        private readonly IProjectEmployeeService _projectEmployeeService;

        public ProjectEmployeeController(IProjectEmployeeService projectEmployeeService)
        {
            _projectEmployeeService = projectEmployeeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEmployee>> GetProjectEmployeeById(int id)
        {
            var projectEmployee = await _projectEmployeeService.GetProjectEmployeeByIdAsync(id);
            if (projectEmployee == null)
            {
                return NotFound();
            }
            return Ok(projectEmployee);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectEmployee>>> GetAllProjectEmployees()
        {
            var projectEmployees = await _projectEmployeeService.GetAllProjectEmployeesAsync();
            return Ok(projectEmployees);
        }
    }
}