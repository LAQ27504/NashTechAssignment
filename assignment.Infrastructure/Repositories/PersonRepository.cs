using assignment.Application.Interface.Gateway;
using assignment.Domain.Entities;
using assignment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace assignment.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            // Person newPerson = Mapper(person);
            Person newPerson = person;

            await _context.Persons.AddAsync(newPerson);

            await _context.SaveChangesAsync();

            return newPerson;
        }

        public async Task<bool> DeletePerson(Guid id)
        {
            Person deletePerson = await _context.Persons.FindAsync(id) ?? throw new Exception("Person not found");

            _context.Persons.Remove(deletePerson);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Person>> FilterData(string? name, HumanGender? gender, string? birthPlace)
        {
            IQueryable<Person> query = _context.Persons.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if (gender.HasValue)
            {
                query = query.Where(p => p.Gender == gender.Value);
            }

            if (!string.IsNullOrEmpty(birthPlace))
            {
                query = query.Where(p => p.BirthPlace.Contains(birthPlace));
            }
            return await query.ToListAsync();
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            Person updatePerson = await _context.Persons.FindAsync(person.Id) ?? throw new Exception("Person not found");
            updatePerson = person;
            await _context.SaveChangesAsync();
            return updatePerson;

        }

        public async Task<IEnumerable<Person>> GetAllPerson()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}