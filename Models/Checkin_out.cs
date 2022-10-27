using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Library.Models
{
    public class Checkin_out
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Checkin_outID { get; set; }
        public int StudentID { get; set; }
        public int StaffID { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }

        public Student Student { get; set; }
        public Staff Staff { get; set; }
    }
}