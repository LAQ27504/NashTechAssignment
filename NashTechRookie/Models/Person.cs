namespace NashTechRookie2.Models
{

    public class Person
    {
        public string? FirstName { get; }
        public string? LastName { get; }
        public string FullName => $"{LastName} {FirstName}";
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? BirthPlace { get; private set; }
        public string IsGraduated { get; private set; }

        public Person(string? firstName,
        string? lastName,
        Gender gender,
        DateTime dateOfBirth,
        string? phoneNumber,
        string? birthPlace,
        bool isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated ? "Yes" : "No";
        }
    }


}
