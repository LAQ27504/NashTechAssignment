using System.ComponentModel.DataAnnotations;

namespace assignment.Application.DTOs
{
    public class PersonConfigRequest
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public required string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";


        public DateTime DateOfBirth { get; set; }

        public HumanGender Gender { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public required string BirthPlace { get; set; }
    }
}