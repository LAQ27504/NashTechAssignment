using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}