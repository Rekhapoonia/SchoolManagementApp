using Microsoft.AspNetCore.Mvc.ActionConstraints;
using SchoolManagementApp.Application.Dto;
using SchoolManagementApp.Data;
using SchoolManagementApp.Infrastructure.Interface;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;
        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
                IEnumerable<Student> students = (from s in _context.Students
                                                 select s
                                                 ).ToList();
                return students;
        }
        public async Task CreateStudentAsync(StudentDto studentDto)
        {
            try
            {
                Student student = new Student()
                {
                    Name = studentDto.Name,
                    Age = studentDto.Age,
                    Image = studentDto.Image,
                    Class = studentDto.Class,
                    RollNumber = studentDto.RollNumber
                };
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while adding student.", ex);
            }
            throw new NotImplementedException();
        }
    }
}
