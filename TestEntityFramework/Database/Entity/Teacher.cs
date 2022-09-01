using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TestEntityFramework.Database.Entity
{
    [Table("Teacher", Schema = "dbo")]
    public class Teacher
    {
        [Key]
        public Guid TeacherGUID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
