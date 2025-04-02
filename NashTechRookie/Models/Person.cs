using System.ComponentModel.DataAnnotations;

namespace NashTechRookie.Models
{

    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string BirthPlace { get; set; }

        public bool IsGraduated { get; set; }

        public string IsGraduatedString => IsGraduated ? "Yes" : "No";
        public string DateOfBirthString => DateOfBirth.ToString("dd/MM/yyyy");

        public Person()
        {

        }

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
