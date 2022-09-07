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
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=TestEntityFramework;User Id=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;");
            }
        }

        public virtual DbSet<Home> Home { get; set; }

        public virtual DbSet<Student> Student { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to one
            modelBuilder.Entity<Student>()
                .HasOne(a => a.Home)
                .WithOne(b => b.Student)
                .HasForeignKey<Home>(b => b.StudentGUID);


            // One to many
            modelBuilder.Entity<Book>()
                .HasOne<Student>(s => s.Student)
                .WithMany(g => g.Books)
                .HasForeignKey(s => s.BookGUID);



            // Many to many
            modelBuilder.Entity<StudentTeacher>().HasKey(sc => new { sc.StudentGUID, sc.TeacherGUID });

            modelBuilder.Entity<StudentTeacher>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentTeachers)
                .HasForeignKey(sc => sc.StudentGUID);

            modelBuilder.Entity<StudentTeacher>()
                .HasOne<Teacher>(sc => sc.Teacher)
                .WithMany(s => s.StudentTeachers)
                .HasForeignKey(sc => sc.TeacherGUID);
        }
    }
}
