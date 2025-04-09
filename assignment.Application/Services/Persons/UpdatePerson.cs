using System.Data.Common;
using assignment.Application.DTOs;
using assignment.Application.Interface.Gateway;
using assignment.Application.Interface.Persons;
using assignment.Application.Mapper;
using assignment.Domain.Entities;

namespace assignment.Application.Services.Persons
{
    public class UpdatePerson : IUpdate
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Execute(Guid id, PersonConfigRequest person)
        {
            Person updatePerson = ToPersonEntity.ToEntity(person);
            return await _personRepository.UpdatePerson(id, updatePerson);
        }
    }
}