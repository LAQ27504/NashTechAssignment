namespace assignment.API.Controllers
{
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound(new { Message = "Project not found" });
            }
            return Ok(project);
        }
        [HttpPost]
        public async Task<ActionResult<Project>> AddProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest(new { Message = "Invalid project data" });
            }

            var createdProject = await _projectService.AddProjectAsync(project);
            return Ok(createdProject);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject([FromBody] Project project)
        {
            var updatedProject = await _projectService.UpdateProjectAsync(project);
            if (updatedProject == null)
            {
                return NotFound(new { Message = "Project not found" });
            }
            return Ok(updatedProject);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deleted = await _projectService.DeleteProjectAsync(id);
            if (!deleted)
            {
                return NotFound(new { Message = "Project not found" });
            }
            return NoContent();
        }
    }
}