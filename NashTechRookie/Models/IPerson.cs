
namespace NashTechRookie.Models
{
    public interface IPerson
    {
        void Create(
            Person person
        );

        void Update(
            Person person
        );

        void Delete(
            Person person
        );

        List<Person> ListAll();
    }
}
