using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HelloMvc.Models.DI;
using HelloMvc.Models.VM;
using HelloMvc.Repo;

namespace HelloMvc.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {


            

           


            var pref = "sms"; //FROM DB
            ISender notificationSender;

            if (pref == "sms") {
                notificationSender = new SmsSender();

            } else {
                notificationSender = new EmailSender();

            }

            var account = new Account(notificationSender);
            account.Deposit(10);
            account.Transfer(10,"343434");



            //ViewBag.Name = "Orest";
            ViewData["Name"] = "Orest";
            ViewBag.Age = 3;

            var emloyees = new List<Employee>()
                            {
                new Employee() {FirstName = "Orest"},
                new Employee() {FirstName = "Bob"}
            };

            var vm = new HomeVm() {
                Employees = emloyees,
                PageName = "Home"
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(string arg1, string arg2, string op) {
            ViewBag.Result = int.Parse(arg1) + int.Parse(arg2);

            return View();
        }


        public IActionResult Privacy() {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}