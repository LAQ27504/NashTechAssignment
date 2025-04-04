namespace assignment.Application.Interface.Task
{
    using System;
    using System.Threading.Tasks;

    public interface IDeleteBulk
    {
        Task<bool> Execute(IEnumerable<Guid> ids);
    }
}