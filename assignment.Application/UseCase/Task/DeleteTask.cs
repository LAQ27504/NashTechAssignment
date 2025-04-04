namespace assignment.Application.UseCase.Task
{
    using assignment.Application.Interface.Task;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Gateway;

    public class DeleteTask : IDelete
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTask(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Execute(Guid id)
        {
            return await _taskRepository.DeleteTask(id);
        }
    }
}