using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {

        }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
