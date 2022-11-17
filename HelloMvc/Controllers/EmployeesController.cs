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

        public IActionResult Hello(string search) {
            return View();
        }

        //Create New User
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model) {
            _repo.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var employee = _repo.GetById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee) {

            var results = _repo.Update(employee);
            if (results) {
                return RedirectToAction("Index");
            }
            return View(employee);
        }



        [HttpGet]
        public IActionResult Details(int id) {
            var employee = _repo.GetByIdWithDetails(id);
            return View(employee);
        }


        [HttpGet]
        public IActionResult Delete(int id) {
            var employee = _repo.GetById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee) {

            var results = _repo.Delete(employee.EmployeeId);
            if (results) {
                return RedirectToAction("Index");
            }
            return View(employee);
        }

    }
}
