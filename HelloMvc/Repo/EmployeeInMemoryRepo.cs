using HelloMvc.Models;

namespace HelloMvc.Repo {
    public class EmployeeInMemoryRepo : IEmployeeRepo {
        private List<Employee> employees = new List<Employee>() {
            new Employee() {EmployeeId = 1, FirstName = "Bob", LastName = "Test"},
            new Employee() {EmployeeId = 2, FirstName = "Mitch", LastName = "Lee"}
        };

        public int Add(Employee employee) {
            employee.EmployeeId = employees.Max(p => p.EmployeeId) + 1;
            employees.Add(employee);
            return employee.EmployeeId;
        }

        public bool Delete(int employeeId) {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll() {
            return employees;
        }

        //this week
        public List<Employee> GetBirthdayBoysAndGirls()
        {
            var from = DateTime.Now.AddDays(-3);
            var to = DateTime.Now.AddDays(5);
            throw new NotImplementedException();
        }

        public Employee GetById(int employeeId) {
            throw new NotImplementedException();
        }

        public Employee GetByIdWithDetails(int employeeId)
        {
            throw new NotImplementedException();
        }

        //this week 
        public List<Employee> GetOnVacation() {

            var from = DateTime.Now.AddDays(-3);
            var to = DateTime.Now.AddDays(5);

            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesInOffice()
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee employee) {
            throw new NotImplementedException();
        }
    }
}
