namespace assignment.Application.Service.Task
{
    using assignment.Application.Interface.Task;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Gateway;

    public class EditTask : IEdit
    {
        private readonly ITaskRepository _taskRepository;

        public EditTask(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskItem?> Execute(Guid id, TaskItem taskItem)
        {
            if (string.IsNullOrWhiteSpace(taskItem.Title) || taskItem.Title.Length < 3 || taskItem.Title.Length > 100)
            {
                throw new ArgumentException("Title must be between 3 and 100 characters.");
            }
            return await _taskRepository.UpdateTask(id, taskItem);
        }
    }
}