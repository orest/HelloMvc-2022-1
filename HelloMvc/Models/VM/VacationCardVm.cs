namespace HelloMvc.Models.VM {
    public class VacationCardVm {
        public int EmployeeId { get; set; }
        public int Mode { get; set; }
        public List<Vacation> Vacations { get; set; }

    }
}
