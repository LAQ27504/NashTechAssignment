using assignment.Domain.Entities;

namespace assignment.Infrastructure.Gateway
{
    public interface ITaskRepository
    {
        Task<TaskItem> CreateTask(TaskItem task);
        Task<IEnumerable<TaskItem>> GetAllTask();
        Task<TaskItem?> GetTaskById(Guid id);
        Task<bool> DeleteTask(Guid id);
        Task<TaskItem?> UpdateTask(Guid id, TaskItem task);
        Task<IEnumerable<TaskItem>> BulkAddTasks(IEnumerable<string> titles);

        Task<bool> BulkDeleteTasks(IEnumerable<Guid> ids);
    }
}