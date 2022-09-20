namespace School_Library.Models
{
    public class Staff 
    {
        public int StaffID { get; set; }
        public string NameStaff { get; set; }
        public string Dayofbirth { get; set; }
        public string PhoneNumber { get; set; }

        public Checkin_out Checkin_out { get; set; }
    }
}
