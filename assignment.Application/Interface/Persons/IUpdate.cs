using assignment.Application.DTOs;
using assignment.Domain.Entities;

namespace assignment.Application.Interface.Persons
{
    public interface IUpdate
    {
        Task<Person> Execute(Guid id, PersonConfigRequest person);
    }
}