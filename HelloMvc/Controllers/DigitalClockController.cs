using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers {
    public class DigitalClockController : Controller {
        public IActionResult Index() {
            var hours = DateTime.Now.Hour;
            var minutes = DateTime.Now.Minute;

            //ViewBag.Hours=hours%12;
            //ViewBag.Minutes = minutes;
            //ViewBag.AmPm = hours <= 12 ? "AM" : "PM";

            var vm = new DigitalClock();
            vm.Hours = hours % 12;
            vm.Minutes = minutes;
            vm.AmPm = hours <= 12 ? "AM" : "PM";

            return View(vm);
        }

        [HttpPost]
        //public IActionResult Index(int hours, int minutes, string amPm) {
        public IActionResult Index(DigitalClock digitalClock) {

            digitalClock.Time = $"{digitalClock.Hours}:" +
                                $"{digitalClock.Minutes} {digitalClock.AmPm}";
            return View(digitalClock);
        }

    }
}
