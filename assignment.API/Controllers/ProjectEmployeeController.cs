namespace assignment.API.Controllers
{
    using assignment.Application.DTOs.Request;
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
            var projectEmployee = await _projectEmployeeService.GetProjectEmployeeByProjectID(id);
            if (projectEmployee == null)
            {
                return NotFound();
            }
            return Ok(projectEmployee);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectEmployee>>> GetAllProjectEmployees()
        {
            var projectEmployees = await _projectEmployeeService.GetAllProjectEmployees();
            return Ok(projectEmployees);
        }
        [HttpPost]
        public async Task<ActionResult<ProjectEmployee>> AddProjectEmployee([FromBody] ProjectEmployeeRequest projectEmployee)
        {
            if (projectEmployee == null)
            {
                return BadRequest();
            }
            var createdProjectEmployee = await _projectEmployeeService.AddProjectEmployee(projectEmployee);
            return Ok(createdProjectEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectEmployee(ProjectEmployeeRequest projectEmployee)
        {
            var success = await _projectEmployeeService.DeletProjectEmployee(projectEmployee);
            if (!success)
            {
                return NotFound();
            }
            return Ok("Delete successfully");
        }

    }
}