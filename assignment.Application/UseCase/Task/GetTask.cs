namespace assignment.Application.UseCase.Task
{
    using assignment.Application.Interface.Task;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Gateway;

    public class GetTask : IGetById
    {
        private readonly ITaskRepository _taskRepository;

        public GetTask(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskItem?> Execute(Guid id)
        {
            return await _taskRepository.GetTaskById(id);
        }
    }
}