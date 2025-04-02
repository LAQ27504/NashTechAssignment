namespace NashTechRookie
{
    public interface IPerson
    {
        public int Id { get; set; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public string FullName => $"{LastName} {FirstName}";
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public string IsGraduated { get; set; }


        void Create();

        void Update();

        void Delete(int id);

        List<IPerson> ListAll();
    }
}
