using ClassesWebsite.Data;
using ClassesWebsite.Models;

namespace ClassesWebsite.Services
{
    public class StudentService : BaseService<Student>
    {
        public StudentService(ClassesDbContext context) : base(context) { }
    }
}
