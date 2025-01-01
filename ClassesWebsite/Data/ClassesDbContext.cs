using ClassesWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassesWebsite.Data
{
    public class ClassesDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        public ClassesDbContext(DbContextOptions<ClassesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuring relationships
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Country)
                .WithMany()
                .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.State)
                .WithMany()
                .HasForeignKey(s => s.StateId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.City)
                .WithMany()
                .HasForeignKey(s => s.CityId);
        }
    }
}
