namespace assignment.Application.Service.Task
{
    using assignment.Application.Interface.Task;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Gateway;

    public class ListAllTasks : IGetAll
    {
        private readonly ITaskRepository _taskRepository;

        public ListAllTasks(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskItem>> Execute()
        {
            return await _taskRepository.GetAllTask();
        }
    }
}