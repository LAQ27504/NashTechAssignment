using NashTechRookie.Models;

namespace NashTechRookie.Data;

public class PersonData
{

    public List<Person> Persons { get; } =
    [
        new("Rebecca", "Chambers", Gender.Female, new DateTime(1994, 9, 9), "901-234-5678", "Dallas", true),
        new("Albert", "Wesker", Gender.Male, new DateTime(1979, 10, 10), "012-345-6789", "Austin", false),
        new("Ada", "Wong", Gender.Female, new DateTime(1990, 11, 11), "123-987-6543", "San Francisco", true),
        new("Carlos", "Oliveira", Gender.Male, new DateTime(1986, 12, 12), "234-876-5432", "Seattle", false),
        new("Barry", "Burton", Gender.Male, new DateTime(1980, 5, 20), "345-765-4321", "Boston", true),
        new("Hunk", "Unknown", Gender.Male, new DateTime(1982, 6, 15), "456-654-3210", "Miami", false),
        new("Sheva", "Alomar", Gender.Female, new DateTime(1993, 7, 25), "567-543-2109", "Denver", true),
        new("Josh", "Stone", Gender.Male, new DateTime(1984, 8, 30), "678-432-1098", "Atlanta", true),
        new("Sherry", "Birkin", Gender.Female, new DateTime(1997, 9, 18), "789-321-0987", "Portland", false),
        new("Billy", "Coen", Gender.Male, new DateTime(1981, 10, 5), "890-210-9876", "Las Vegas", true),
        new("Piers", "Nivans", Gender.Male, new DateTime(1992, 11, 22), "901-109-8765", "Nashville", false)
    ];

}