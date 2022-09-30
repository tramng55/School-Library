using Microsoft.AspNetCore.Mvc;

namespace School_Library.Models.BookViewModel
{
    public class BookViewModel 
    {
        public int BookID { get; set; }
        public string NameBook { get; set; }

        public Category Category { get; set; }
        public List <Author> Authors { get; set; }
    }
}
