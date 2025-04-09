using System.ComponentModel.DataAnnotations;

namespace assignment.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public HumanGender Gender { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string BirthPlace { get; set; }

        public Person(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            HumanGender gender,
            string birthPlace
            )
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            BirthPlace = birthPlace;
        }
    }
}

