using System.ComponentModel.DataAnnotations;

namespace assignment.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public DateTime JoinedDate { get; set; }

        public string? Name { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public Salaries? Salary { get; set; }

        public ICollection<ProjectEmployee>? ProjectEmployees { get; set; }

    }
}