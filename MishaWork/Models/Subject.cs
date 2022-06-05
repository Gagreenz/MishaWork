using System.ComponentModel.DataAnnotations;

namespace MishaWork.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TeacherComment { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Path { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        IFormFile file { get; set; }

    }
}