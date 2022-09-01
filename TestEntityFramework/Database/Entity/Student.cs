using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Collections.Generic;

namespace TestEntityFramework.Database.Entity
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        [Key]
        public Guid StudentGUID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Home Home { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
