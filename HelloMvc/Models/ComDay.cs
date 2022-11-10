namespace HelloMvc.Models {
    public class ComDay {
        public int Id { get; set; }
        public DateTime CompDate { get; set; }
        public DateTime?  DateTakenInstead  { get; set; }
        public int HolidayId { get; set; }
        public string Comment { get; set; }


    }
}
