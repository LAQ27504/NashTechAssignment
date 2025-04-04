namespace assignment.Application.Interface.Task
{
    using System;
    using System.Threading.Tasks;

    public interface IDelete
    {
        Task<bool> Execute(Guid id);
    }
}