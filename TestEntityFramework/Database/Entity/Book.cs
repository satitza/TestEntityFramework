using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityFramework.Database.Entity
{
    [Table("Book", Schema = "dbo")]
    public class Book
    {
        [Key]
        public Guid BookGUID {get; set; }

        public string BookName { get; set; }

        public int BookCode { get; set; }

        public Guid StudentGUID { get; set; }
        public Student Student { get; set; }
    }
}
