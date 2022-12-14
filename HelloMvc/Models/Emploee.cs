using System.ComponentModel.DataAnnotations;

namespace HelloMvc.Models {
    public class Employee {
        public Employee()
        {
            Vacations = new List<Vacation>();
        }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string DaysInOffice { get; set; }
        public DateTime StartWorkingTime { get; set; }
        public DateTime EndWorkingTime { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Vacation> Vacations { get; set; }

    }
}
