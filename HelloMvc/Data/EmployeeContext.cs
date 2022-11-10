using HelloMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Data {
    public class EmployeeContext : DbContext {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

    }
}
