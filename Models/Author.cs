namespace School_Library.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string NameAuthor { get; set; }
        public string NameBook { get; set; }
        public string Status { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }

    }
}
