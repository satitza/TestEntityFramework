using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestEntityFramework.Database.Entity;

namespace TestEntityFramework.Database.Context
{
    public class TestEntityframeworkContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=TestEntityFramework;User Id=sa;Password=dr823c1HEE;MultipleActiveResultSets=true;");
            }
        }

        public virtual DbSet<Home> Home { get; set; }

        public virtual DbSet<Student> Student { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(a => a.Home)
                .WithOne(b => b.Student)
                .HasForeignKey<Home>(b => b.StudentGUID);

            modelBuilder.Entity<Book>()
                .HasOne<Student>(s => s.Student)
                .WithMany(g => g.Books)
                .HasForeignKey(s => s.BookGUID);


            modelBuilder.Entity<StudentTeacher>().HasKey(sc => new { sc.StudentGUID, sc.TeacherGUID });
        }
    }
}
