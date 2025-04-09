using assignment.Application.Interface.Gateway;
using assignment.Application.Interface.Persons;
using assignment.Domain.Entities;

namespace assignment.Application.Service.Persons
{
    public class CreatePerson : ICreate
    {
        private readonly IPersonRepository _personRepository;

        public CreatePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Execute(Person person)
        {
            // Create a new person
            Person newPerson = person;

            return await _personRepository.CreatePerson(newPerson);
        }
    }
}