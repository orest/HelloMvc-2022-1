using HelloMvc.Models;

namespace HelloMvc.Repo {
    //CRUD
    public interface IEmployeeRepo {
        int Add(Employee employee);
        List<Employee> GetAll();
        Employee GetById(int employeeId);
        bool Update(Employee employee);
        bool Delete(int employeeId);
        List<Employee> GetBirthdayBoysAndGirls();
        List<Employee> GetOnVacation();
        List<Employee> GetEmployeesInOffice();

    }
}
