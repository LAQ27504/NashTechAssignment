namespace assignment.Application.Interface.Task
{
    using System;
    using System.Threading.Tasks;
    using assignment.Domain.Entities;

    public interface IGetById
    {
        Task<TaskItem?> Execute(Guid id);
    }
}