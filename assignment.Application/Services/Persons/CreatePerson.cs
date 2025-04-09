using assignment.Application.DTOs;
using assignment.Application.Interface.Gateway;
using assignment.Application.Interface.Persons;
using assignment.Application.Mapper;
using assignment.Domain.Entities;

namespace assignment.Application.Services.Persons
{
    public class CreatePerson : ICreate
    {
        private readonly IPersonRepository _personRepository;

        public CreatePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Execute(PersonConfigRequest person)
        {
            // Create a new person
            Person newPerson = ToPersonEntity.ToEntity(person);

            return await _personRepository.CreatePerson(newPerson);
        }
    }
}