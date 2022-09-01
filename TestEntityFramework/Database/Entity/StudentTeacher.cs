using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityFramework.Database.Entity
{
    [Table("StudentTeacher", Schema = "dbo")]
    public class StudentTeacher
    {
        [Key]
        public Guid StudentGUID { get; set; }
        public Student Student { get; set; }

        [Key]
        public Guid TeacherGUID { get; set; }
        public Teacher Teacher { get;  set; }
    }
}
