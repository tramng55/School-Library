using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Library.Models
{
    public class BorrowAssignment 
    {
        public int BorrowAssignmentID { get; set; } 
        public int BookID { get; set; }
        public int StudentID { get; set; }
        public string NameBook { get; set; }
        public string NameStudent { get; set; }
        public string Status { get; set; }

        public Book Book { get; set; }
        public Student Student { get; set; }


    }
}
