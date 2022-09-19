namespace School_Library.Models
{
    public class Borrow
    {
        public int StudentID { get; set; }
        public int BookID { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Update { get; set; }
        public string Status { get; set; }

    }
}
