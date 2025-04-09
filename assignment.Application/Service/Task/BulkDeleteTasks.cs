namespace assignment.Application.Service.Task
{
    using assignment.Application.Interface.Task;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Gateway;

    public class BulkDeleteTasks : IDeleteBulk
    {
        private readonly ITaskRepository _taskRepository;

        public BulkDeleteTasks(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Execute(IEnumerable<Guid> ids)
        {
            return await _taskRepository.BulkDeleteTasks(ids);
        }
    }
}