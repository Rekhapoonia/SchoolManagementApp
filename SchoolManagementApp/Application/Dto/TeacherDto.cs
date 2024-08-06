using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Application.Dto
{
    public class TeacherDto
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
    }
}
