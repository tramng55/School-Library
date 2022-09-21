using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Library.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        
        public string NameBook { get; set; }
        
        //public ICollection<Author> Authors { get; set; }
        public Category Categories { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<BorrowAssignment> BorrowAssignments { get; set; }
        public ICollection<Producer> Producers { get; set; }
       
    }
}