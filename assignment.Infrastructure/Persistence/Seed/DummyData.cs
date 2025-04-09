
using assignment.Domain.Entities;
using assignment.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace assignment.Infrastructure.Persistence.Seed
{
    public class DummyData
    {
        private readonly ApplicationDbContext _context;

        public DummyData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Initialize()
        {
            if (await _context.Persons.AnyAsync()) return;

            await _context.Persons.AddRangeAsync(
                new Person("John", "Doe", new DateTime(1992, 5, 15), HumanGender.Male, "New York"),
                new Person("Jane", "Smith", new DateTime(1988, 7, 22), HumanGender.Female, "Los Angeles"),
                new Person("Sam", "Lee", new DateTime(2004, 3, 10), HumanGender.Other, "Chicago"),
                new Person("Anna", "Brown", new DateTime(2000, 11, 5), HumanGender.Female, "Houston"),
                new Person("Mike", "Johnson", new DateTime(1996, 1, 30), HumanGender.Male, "Phoenix")
            );

            await _context.SaveChangesAsync();

        }
    }

}
