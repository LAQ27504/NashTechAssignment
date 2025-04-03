using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("to-do-list/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        // 🔹 Inject the service using Constructor Injection
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskModel task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdTask = _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_taskService.GetAllTasks());
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            return task != null ? Ok(task) : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            return _taskService.DeleteTask(id) ? NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskModel updatedTask)
        {
            var task = _taskService.UpdateTask(id, updatedTask);
            return task != null ? Ok(task) : NotFound();
        }

        [HttpPost("bulk")]
        public IActionResult BulkAddTasks([FromBody] List<TaskModel> tasks)
        {
            return Ok(_taskService.BulkAddTasks(tasks));
        }

        [HttpDelete("bulk")]
        public IActionResult BulkDeleteTasks([FromBody] List<int> taskIds)
        {
            return _taskService.BulkDeleteTasks(taskIds) ? NoContent() : BadRequest();
        }
    }
}
