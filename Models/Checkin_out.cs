namespace School_Library.Models
{
    public class Checkin_out 
    {
        public int StudentID { get; set; }
        public int StaffID { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Status { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Staff> Staffs { get; set; }


    }
}
