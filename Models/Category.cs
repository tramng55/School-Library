namespace School_Library.Models
{
    public class Category 
    {
        public int CategoryID { get; set; }
        public string NameCategory { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
