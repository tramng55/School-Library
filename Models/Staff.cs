using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace School_Library.Models
{
    public class Staff 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }
        public string NameStaff { get; set; }
        public string Dayofbirth { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection <Checkin_out> Checkin_outs { get; set; }
    }
}
