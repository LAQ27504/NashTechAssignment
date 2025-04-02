
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

        void Delete();

        List<IPerson> ListAll();
    }
}
