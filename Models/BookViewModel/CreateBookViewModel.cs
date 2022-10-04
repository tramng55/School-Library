using Microsoft.AspNetCore.Mvc;

namespace School_Library.Models.BookViewModel
{
    public class CreateBookViewModel
    {
        public int CategoryID { get; set; }
        public string NameBook { get; set; }

        public List<int> AuthorIDs { get; set; }
    }
}
