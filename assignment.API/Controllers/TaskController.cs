using assignment.Application.Task.Create;
using assignment.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace assignment.API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly CreateTask _taskService;

        public TaskController(CreateTask taskService)
        {
            _taskService = taskService;
        }

        // Get all tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // Get a task by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // Create a new task
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] string task)
        {
            if (task == null)
                return BadRequest("Task cannot be null.");

            var createdTask = await _taskService.Execute(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        // Update a task
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskItem task)
        {
            if (task == null)
                return BadRequest("Task cannot be null.");

            var updatedTask = await _taskService.UpdateTask(id, task);
            if (updatedTask == null)
                return NotFound();

            return Ok(updatedTask);
        }

        // Delete a task
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var deleted = await _taskService.DeleteTask(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
