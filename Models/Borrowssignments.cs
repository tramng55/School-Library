using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace School_Library.Models
{
    public class BorrowAssignment 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BorrowAssignmentID { get; set; } 
        public int BookID { get; set; }
        public int StudentID { get; set; }
        public int Status { get; set; }

        public Book Book { get; set; }
        public Student Student { get; set; }


    }
}
