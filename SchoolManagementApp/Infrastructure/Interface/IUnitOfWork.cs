namespace SchoolManagementApp.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        IStudentRepository studentRepository { get; }
        ITeacherRepositry teacherRepositry { get; }
        ISubjectRepository subjectRepository { get; }
        
    }
}
