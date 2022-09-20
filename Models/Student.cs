namespace School_Library.Models
{
    public class Student 
    {
        public int StudentID { get; set; }
        public string NameStudent { get; set; }
        public string Dayofbirth { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<BorrowAssignment> BorrowAssignment { get; set; }
        public ICollection<Checkin_out> Checkin_out { get; set; }



    }
}