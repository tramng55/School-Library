namespace School_Library.Models
{
    public class BorrowAssignment 
    {
        public int BookID { get; set; }
        public int StudentID { get; set; }
        public string Status { get; set; }

        public Book Book { get; set; }
        public Student Student { get; set; }


    }
}
