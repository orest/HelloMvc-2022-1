using HelloMvc.Repo;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Components {
    public class EmployeesInOffice : ViewComponent {
        private readonly IEmployeeRepo _repo;

        public EmployeesInOffice(IEmployeeRepo repo) {
            _repo = repo;
        }
        public IViewComponentResult Invoke() {
            var vm = _repo.GetEmployeesInOffice();
            return View(vm);
        }
    }
}
