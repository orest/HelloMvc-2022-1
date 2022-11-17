using HelloMvc.Data;
using HelloMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Repo {
    public class EmployeeRepo : IEmployeeRepo {
        private readonly EmployeeContext _context;

        public EmployeeRepo(EmployeeContext context) {
            _context = context;

            var day = DateTime.Now.DayOfWeek.ToString();
        }

        public int Add(Employee employee) {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.EmployeeId;
        }

        public List<Employee> GetAll() {

            var emplpoyees = _context.Employees
                .Include(p => p.Vacations.Where(v => v.FromDate > DateTime.Today))
                .ToList();

            //foreach (var emplpoyee in emplpoyees)
            //{
            //    emplpoyee.Vacations = emplpoyee.Vacations.Where(p => p.FromDate > DateTime.Now).ToList();
            //}

            return emplpoyees;
        }

        public Employee GetById(int employeeId) {
            return _context.Employees.Find(employeeId);
            //return _context.Employees.FirstOrDefault(p=>p.EmployeeId==employeeId);
        }

        public Employee GetByIdWithDetails(int employeeId) {
            var employee = _context.Employees
                .Include(p => p.Vacations)
                .FirstOrDefault(p => p.EmployeeId == employeeId);

            return employee;
        }

        public bool Update(Employee employee) {
            try {
                var entity = _context.Employees.Find(employee.EmployeeId);
                entity.DateOfBirth = employee.DateOfBirth;
                entity.FirstName = employee.FirstName;
                entity.LastName = employee.LastName;
                entity.LastName = employee.LastName;
                entity.DaysInOffice = employee.DaysInOffice;
                entity.PhoneNumber = employee.PhoneNumber;
                entity.EndWorkingTime = employee.EndWorkingTime;
                entity.StartWorkingTime = employee.StartWorkingTime;
                _context.SaveChanges();

            } catch (Exception e) {
                return false;
            }


            return true;
        }

        public bool Delete(int employeeId) {
            var entity = _context.Employees.Find(employeeId);
            if (entity == null) {
                return false;
            } else {
                _context.Employees.Remove(entity);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Employee> GetBirthdayBoysAndGirls() {
            throw new NotImplementedException();
        }

        public List<Employee> GetOnVacation() {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesInOffice() {
            var today = DateTime.Today.DayOfWeek;
            var searchExpression = $"%{today.ToString()}%";

            var data = _context.Employees.Where(p => EF.Functions.Like(p.DaysInOffice, searchExpression))
                .ToList();

            return data;
        }
    }
}
