using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloMvc.Models {
    public class DigitalClock {
        public DigitalClock()
        {
            AmPmItems = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = ""},
                new SelectListItem() {Value = "AM", Text = "AM"},
                new SelectListItem() {Value = "PM", Text = "PM"},
            };
        }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string AmPm { get; set; }
        public string Time { get; set; }

        public List<SelectListItem> AmPmItems  { get; set; }
    }
}
