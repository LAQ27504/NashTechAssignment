using assignment.Application.Interface.Task;
using assignment.Domain.Entities;
using assignment.Infrastructure.Gateway;

namespace assignment.Application.Task
{
    public class CreateTask : ICreate
    {
        private readonly ITaskRepository _taskRepository;
        public CreateTask(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskItem> Execute(string title)
        {

            // Validate the title
            if (string.IsNullOrWhiteSpace(title) || title.Length < 3 || title.Length > 100)
            {
                throw new ArgumentException("Title must be between 3 and 100 characters.");
            }

            // Create a new task item
            var taskItem = new TaskItem(title);

            return await _taskRepository.CreateTask(taskItem);
        }
    }
}