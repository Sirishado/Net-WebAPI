using Microsoft.EntityFrameworkCore;

namespace react
{
    public class Student_Context : DbContext
    {
        public Student_Context(DbContextOptions<Student_Context> options) : base(options)
        {
        }

        public DbSet<Student_Entity> student { get; set; }
    }
}
