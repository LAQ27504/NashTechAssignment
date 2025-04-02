using NashTechRookie.Models;

namespace NashTechRookie.Data;

public class PersonData
{

    public List<Person> Persons { get; } =
    [
        new(1,"Rebecca", "Chambers", Gender.Female, new DateTime(1994, 9, 9), "901-234-5678", "Dallas", true),
        new(2,"Albert", "Wesker", Gender.Male, new DateTime(2000, 10, 10), "012-345-6789", "Austin", false),
        new(3,"Ada", "Wong", Gender.Female, new DateTime(1990, 11, 11), "123-987-6543", "San Francisco", true),
        new(4,"Carlos", "Oliveira", Gender.Male, new DateTime(2003, 12, 12), "234-876-5432", "Seattle", false),
        new(5,"Barry", "Burton", Gender.Male, new DateTime(2004, 5, 20), "345-765-4321", "Boston", true),
        new(6,"Hunk", "Unknown", Gender.Male, new DateTime(1982, 6, 15), "456-654-3210", "Miami", false),
        new(7,"Sheva", "Alomar", Gender.Female, new DateTime(2005, 7, 25), "567-543-2109", "Denver", true),
        new(8,"Josh", "Stone", Gender.Male, new DateTime(1984, 8, 30), "678-432-1098", "Atlanta", true),
        new(9,"Sherry", "Birkin", Gender.Female, new DateTime(1997, 9, 18), "789-321-0987", "Portland", false),
        new(10,"Billy", "Coen", Gender.Male, new DateTime(2001, 10, 5), "890-210-9876", "Las Vegas", true),
        new(11,"Piers", "Nivans", Gender.Male, new DateTime(1992, 11, 22), "901-109-8765", "Nashville", false)
    ];

}