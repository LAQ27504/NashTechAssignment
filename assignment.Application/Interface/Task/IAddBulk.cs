namespace assignment.Application.Interface.Task
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Domain.Entities;

    public interface IAddBulk
    {
        Task<IEnumerable<TaskItem>> Execute(IEnumerable<string> titles);
    }
}