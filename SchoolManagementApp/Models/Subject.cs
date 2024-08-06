using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        public int Language { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
