namespace assignment.Application.Interface.Task
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Domain.Entities;

    public interface IGetAll
    {
        Task<IEnumerable<TaskItem>> Execute();
    }
}