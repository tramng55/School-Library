namespace School_Library.Models
{
    public class AuthorBook
    {
        public int AuthorID { get; set; }
        public int BookID { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
