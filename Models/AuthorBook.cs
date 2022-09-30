using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace School_Library.Models
{
    public class AuthorBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorBookID { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }
       
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
