using assignment.Application.Interface.Task;
using assignment.Application.Task;
using assignment.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace assignment.API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ICreate _taskCreate;
        private readonly IGetAll _taskGetAll;
        private readonly IGetById _taskGetById;
        private readonly IEdit _taskUpdate;
        private readonly IDelete _taskDelete;
        private readonly IAddBulk _addBulk;
        private readonly IDeleteBulk _deleteBulk;

        public TaskController(
            ICreate taskCreate,
            IGetAll taskGetAll,
            IGetById taskGetById,
            IEdit taskUpdate,
            IDelete taskDelete,
            IAddBulk addBulk,
            IDeleteBulk deleteBulk)
        {
            _taskCreate = taskCreate;
            _taskGetAll = taskGetAll;
            _taskGetById = taskGetById;
            _taskUpdate = taskUpdate;
            _taskDelete = taskDelete;
            _addBulk = addBulk;
            _deleteBulk = deleteBulk;
        }

        // Get all tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskGetAll.Execute();
            return Ok(tasks);
        }

        // Get a task by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskGetById.Execute(id);
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

            var createdTask = await _taskCreate.Execute(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        // Update a task
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskItem task)
        {
            if (task == null)
                return BadRequest("Task cannot be null.");

            var updatedTask = await _taskUpdate.Execute(id, task);
            if (updatedTask == null)
                return NotFound();

            return Ok(updatedTask);
        }

        // Delete a task
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var deleted = await _taskDelete.Execute(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
