using assignment.Domain.Entities;

namespace assignment.Application.Interface.Persons
{
    public interface ICreate
    {
        Task<Person> Execute(Person person);
    }
}