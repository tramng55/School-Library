using Microsoft.AspNetCore.Mvc;

namespace School_Library.Models.BookViewModel
{
    public class EditBookViewModel 
    {
        public int CategoryID { get; set; }
        public string NameBook { get; set; }

        public List<EditAuthorBookViewModel> Authors { get; set; }
        
        
    }
}
