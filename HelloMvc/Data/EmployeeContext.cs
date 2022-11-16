using HelloMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Data {
    public class EmployeeContext : DbContext {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Holiday> Holidays { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holiday>().HasKey(p => p.HolidayCode);
            modelBuilder.Entity<Holiday>().Property(p => p.HolidayCode).HasMaxLength(10);
            modelBuilder.Entity<Holiday>().Property(p => p.DisplayName).HasMaxLength(250);

            modelBuilder.Entity<Holiday>().HasData(new List<Holiday>()
            {
                new Holiday() {DisplayName = "New Year's Day", HolidayCode = "NYD"},
                new Holiday() {DisplayName = "Martin Luther King Jr. Day", HolidayCode = "MLKJD"},
                new Holiday() {DisplayName = "Washington's Birthday", HolidayCode = "WB"},
                new Holiday() {DisplayName = "Memorial Day", HolidayCode = "MD"},
                new Holiday() {DisplayName = "Juneteenth", HolidayCode = "JTTH"},
                new Holiday() {DisplayName = "Independence Day", HolidayCode = "ID"},
                new Holiday() {DisplayName = "Labor Day", HolidayCode = "LD"},
                new Holiday() {DisplayName = "Columbus Day", HolidayCode = "CD"},
                new Holiday() {DisplayName = "Veterans Day", HolidayCode = "VD"},
                new Holiday() {DisplayName = "Thanksgiving", HolidayCode = "TG"},
                new Holiday() {DisplayName = "Christmas", HolidayCode = "CM"},
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
