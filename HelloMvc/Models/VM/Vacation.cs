using System.ComponentModel.DataAnnotations;

namespace HelloMvc.Models {
    public class Vacation {
        public int VacationId { get; set; }
        [Required]
        [Display(Name = "Comment")]
        [MaxLength(100)]
        [MinLength(5)]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate{ get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
