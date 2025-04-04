using assignment.Domain.Entities;

namespace assignment.Application.Interface.Task
{
    public interface ICreate
    {
        Task<TaskItem> Execute(string title);
    }
}