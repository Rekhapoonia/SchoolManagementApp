using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Infrastructure.Interface
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Task CreateSubjectAsync(SubjectDto subjectDto);
    }
}
