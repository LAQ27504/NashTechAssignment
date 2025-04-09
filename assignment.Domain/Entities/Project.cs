namespace assignment.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}