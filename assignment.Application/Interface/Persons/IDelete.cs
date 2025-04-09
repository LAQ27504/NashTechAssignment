using assignment.Domain.Entities;

namespace assignment.Application.Interface.Persons
{
    public interface IDelete
    {
        Task<bool> Execute(Guid id);
    }
}