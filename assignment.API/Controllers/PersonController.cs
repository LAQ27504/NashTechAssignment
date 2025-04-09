using assignment.Application.DTOs;
using assignment.Application.Interface.Persons;
using assignment.Application.Services.Persons;
using assignment.Domain.Entities;
using assignment.Infrastructure.Persistence.Seed;
using Microsoft.AspNetCore.Mvc;

namespace assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly ICreate _personCreate;
        private readonly IListPerson _personGetAll;

        private readonly IUpdate _personUpdate;

        private readonly IDelete _personDelete;

        private readonly IFilter _personFilter;

        public PersonController(
            ICreate personCreate,
            IListPerson personGetAll,
            IUpdate personUpdate,
            IDelete personDelete,
            IFilter personFilter
        )
        {
            _personCreate = personCreate;
            _personGetAll = personGetAll;
            _personUpdate = personUpdate;
            _personDelete = personDelete;
            _personFilter = personFilter;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var persons = await _personGetAll.Execute();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonConfigRequest person)
        {
            var createdPerson = await _personCreate.Execute(person);
            return Ok(createdPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] PersonConfigRequest person)
        {
            var updatePerson = await _personUpdate.Execute(id, person);
            return Ok(updatePerson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var deletePerson = await _personDelete.Execute(id);
            return Ok(deletePerson);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> FilterPersons([FromBody] PersonFilterDto filter)
        {
            var result = await _personFilter.Execute(filter.Name, filter.Gender, filter.BirthPlace);
            return Ok(result);
        }

    }
}