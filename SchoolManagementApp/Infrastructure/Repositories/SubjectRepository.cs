using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Data;
using SchoolManagementApp.Infrastructure.Interface;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolDbContext _context;
        public SubjectRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetAll()
        {
            var subjects = _context.Subjects.Include(s => s.Students)
                .Include(s => s.Teacher).ToList();
            return subjects;
        }

        public async Task CreateSubjectAsync(SubjectDto subjectDto)
        {
            try
            {
                Subject subject = new Subject()
                {
                    Name = subjectDto.Name,
                    Class = subjectDto.Class,
                    Language = subjectDto.Language,
                    StudentId = subjectDto.StudentId,
                    TeacherId = subjectDto.TeacherId
                };
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while adding the subjects.", ex);
            }
           
        }

    }
}
