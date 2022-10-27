using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Library.Models
{
    public class Student 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        public string NameStudent { get; set; }
        public string Dayofbirth { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<BorrowAssignment> BorrowAssignments { get; set; }
        public ICollection <Checkin_out> Checkin_outs { get; set; }



    }
}