using Microsoft.AspNetCore.Mvc;

namespace School_Library.Data
{
    public class DbInitializer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
