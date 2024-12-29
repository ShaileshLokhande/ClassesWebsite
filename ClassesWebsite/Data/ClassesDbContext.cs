using ClassesWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassesWebsite.Data
{
    public class ClassesDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public ClassesDbContext(DbContextOptions<ClassesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
