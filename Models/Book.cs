namespace School_Library.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public int ProducerID { get; set; }
        public string NameBook { get; set; }

        //public ICollection<Author> Authors { get; set; }
        public Category Category { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<BorrowAssignment> BorrowAssignments { get; set; }
        public ICollection<Producer> Producers { get; set; }

    }
}