using SchoolManagementApp.Data;
using SchoolManagementApp.Infrastructure.Interface;
using SchoolManagementApp.Infrastructure.Repositories;

namespace SchoolManagementApp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _context;
        
        public IStudentRepository studentRepository { get; private set; }

        public ITeacherRepositry teacherRepositry { get; private set; }

        public ISubjectRepository subjectRepository { get; private set; }

        public UnitOfWork(SchoolDbContext context)
        {
            _context = context;
            studentRepository = new StudentRepository(_context);
            teacherRepositry = new TeacherRepository(_context);
            subjectRepository = new SubjectRepository(_context);
        }
    }
}
