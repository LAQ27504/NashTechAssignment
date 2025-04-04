using System.ComponentModel.DataAnnotations;

namespace assignment.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            IsCompleted = false;
        }
    }
}