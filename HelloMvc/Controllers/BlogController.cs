using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers {
    public class BlogController : Controller {
        public IActionResult Index(int year, int month, int day) {
            return View();
        }
    }
}
