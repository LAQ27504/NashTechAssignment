namespace assignment.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}