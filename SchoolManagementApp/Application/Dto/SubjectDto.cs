using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Application.Dto
{
    public class SubjectDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        public int Language { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
