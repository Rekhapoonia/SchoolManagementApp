using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Application.Dto
{
    public class StudentDto
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public string Image { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string RollNumber { get; set; }
    }
}
