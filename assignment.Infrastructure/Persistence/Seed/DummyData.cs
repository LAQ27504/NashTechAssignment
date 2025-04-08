using assignment.Domain.Entities;
using assignment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace assignment.Infrastructure.Persistence.Seed
{
    public static class DummyData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check if data already exists
                if (context.Persons.Any())
                {
                    return; // DB has been seeded
                }

                context.Persons.AddRange(
                new Person("John", "Doe", new DateTime(1992, 5, 15), HumanGender.Male, "New York"),
                new Person("Jane", "Smith", new DateTime(1988, 7, 22), HumanGender.Female, "Los Angeles"),
                new Person("Sam", "Lee", new DateTime(2004, 3, 10), HumanGender.Other, "Chicago"),
                new Person("Anna", "Brown", new DateTime(2000, 11, 5), HumanGender.Female, "Houston"),
                new Person("Mike", "Johnson", new DateTime(1996, 1, 30), HumanGender.Male, "Phoenix")
            );

                context.SaveChanges();
            }
        }
    }

}
