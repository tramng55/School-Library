namespace School_Library.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string NameAuthor { get; set; }
        public string Website { get; set; }
        public string Status { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
