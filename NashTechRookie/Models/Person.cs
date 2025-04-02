
namespace NashTechRookie.Models
{

    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public string FullName => $"{LastName} {FirstName}";
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public string IsGraduatedString => IsGraduated ? "Yes" : "No";
        public string DateOfBirthString => DateOfBirth.ToString("dd/MM/yyyy");

        public Person(
        int id,
        string? firstName,
        string? lastName,
        Gender gender,
        DateTime dateOfBirth,
        string? phoneNumber,
        string? birthPlace,
        bool isGraduated)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }
    }
}
