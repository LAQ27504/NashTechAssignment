namespace assignment.Application.UseCase.Task
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Application.Interface.Task;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Gateway;

    public class BulkAddTasks : IAddBulk
    {
        private readonly ITaskRepository _taskRepository;

        public BulkAddTasks(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskItem>> Execute(IEnumerable<string> titles)
        {
            return await _taskRepository.BulkAddTasks(titles);
        }
    }
}