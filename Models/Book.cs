namespace School_Library.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public int ProducerID { get; set; }
        public string Namebook { get; set; }

    }
}