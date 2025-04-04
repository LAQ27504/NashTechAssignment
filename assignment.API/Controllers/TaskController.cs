using Microsoft.AspNetCore.Mvc;
using assignment.Domain.Entities;
using assignment.Infrastructure.Gateway;

namespace assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repo;

        public TasksController(ITaskRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllTask());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var task = await _repo.GetTaskById(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            var created = await _repo.CreateTask(task);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskItem task)
        {
            var updated = await _repo.UpdateTask(id, task);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repo.DeleteTask(id);
            return result ? NoContent() : NotFound();
        }
    }
}
