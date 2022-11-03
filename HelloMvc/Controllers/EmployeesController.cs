using HelloMvc.Models;
using HelloMvc.Repo;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers {
    public class EmployeesController : Controller {
        private readonly IEmployeeRepo _repo;

        public EmployeesController(IEmployeeRepo repo) {
            _repo = repo;
        }

        public IActionResult Index() {

            //var repo = new EmployeeInMemoryRepo();
            return View(_repo.GetAll());
        }



        public IActionResult Hello() {
            return View();
        }

        //Create New User
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            _repo.Add(model);

            return RedirectToAction("Index");
        }




        public IActionResult Edit(int id) {
            //var emp = employees.FirstOrDefault(p => p.EmployeeId == id);
            //return View(emp);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee employee) {
            //apply modified values
            //employees.First().FirstName = "Orest";
            return View(employee);
        }
    }
}
