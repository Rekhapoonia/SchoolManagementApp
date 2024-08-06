using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
