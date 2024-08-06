using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Infrastructure.Interface
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Task CreateStudentAsync(StudentDto studentDto);
    }
}
