namespace assignment.Application.DTOs.Request
{
    using System.ComponentModel.DataAnnotations;
    using System.Formats.Asn1;

    public class DepartmentRequest
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}