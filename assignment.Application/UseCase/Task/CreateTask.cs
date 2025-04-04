using System.Runtime.CompilerServices;
using assignment.Domain.Entities;
using assignment.Infrastructure.Gateway;

namespace assignment.Application.Task.Create
{
    public class CreateTask
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

        public async Task<bool> DeleteTask(Guid id)
        {
            return await _taskRepository.DeleteTask(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _taskRepository.GetAllTask();
        }

        public async Task<TaskItem?> GetTaskById(Guid id)
        {
            return await _taskRepository.GetTaskById(id);
        }

        public async Task<TaskItem?> UpdateTask(Guid id, TaskItem task)
        {
            return await _taskRepository.UpdateTask(id, task);
        }
    }
}