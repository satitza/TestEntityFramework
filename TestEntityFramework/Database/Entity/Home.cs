using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityFramework.Database.Entity
{
    [Table("Home", Schema = "dbo")]
    public class Home
    {
        [Key]
        public Guid HomeGUID { get; set; }

        public string Address { get; set; }

        public Guid StudentGUID { get; set; }

        [ForeignKey("StudentGUID")]
        public Student Student { get; set; }
    }
}
