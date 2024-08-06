using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Infrastructure.Interface
{
    public interface ITeacherRepositry
    {
        IEnumerable<Teacher> GetAll();
        Task CreateTeacherAsync(TeacherDto teacherDto);
    }
}
