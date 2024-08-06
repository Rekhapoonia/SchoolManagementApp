using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Data;
using SchoolManagementApp.Infrastructure.Interface;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepositry
    {
        private readonly SchoolDbContext _context;
        public TeacherRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            IEnumerable<Teacher> teachers = (from t in _context.Teachers
                                             select t
                                                ).ToList();
            return teachers;
        }

        public async Task CreateTeacherAsync(TeacherDto teacherDto)
        {
            try
            {
                Teacher teacher = new Teacher()
                {
                    Name = teacherDto.Name,
                    Image = teacherDto.Image,
                    Age = teacherDto.Age,
                    Sex = teacherDto.Sex
                };
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while adding the teacher.", ex);
            }   
        }
    }
}
