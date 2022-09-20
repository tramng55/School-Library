namespace School_Library.Models
{
    public class Student 
    {
        public int StudentID { get; set; }
        public string NameStudent { get; set; }
        public string Dayofbirth { get; set; }
        public string PhoneNumber { get; set; }
        
        public ICollection<BorrowAssignment> BorrowAssignments { get; set; }
    }
}