using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers {
    public class CalculatorController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string argument1, string op,
            string arg2) {
            return View();
        }
    }
}
