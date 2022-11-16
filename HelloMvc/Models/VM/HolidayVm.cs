
using System.ComponentModel.DataAnnotations;

namespace HelloMvc.Models.VM {
    public class HolidayVm {
        public HolidayVm(Holiday holiday)
        {
            HolidayCode = holiday.HolidayCode;
            DisplayName = holiday.DisplayName;
            CurrentYearDate = ReturnDate(holiday.HolidayCode);
        }
        public string HolidayCode { get; set; }
        [Display(Name = "Holiday Name")]
        public string DisplayName { get; set; }

        public DateTime CurrentYearDate { get; set; }


        private DateTime ReturnDate(string holidayCode) {
            switch (holidayCode) {
                case "MD": {
                        DateTime memorialDay = new DateTime(DateTime.Today.Year, 5, 31);
                        DayOfWeek dayOfWeek = memorialDay.DayOfWeek;
                        while (dayOfWeek != DayOfWeek.Monday) {
                            memorialDay = memorialDay.AddDays(-1);
                            dayOfWeek = memorialDay.DayOfWeek;
                        }
                        return memorialDay;
                    }
                case "LD": {
                        DateTime laborDay = new DateTime(DateTime.Today.Year, 9, 1);
                        DayOfWeek dayOfWeek = laborDay.DayOfWeek;
                        while (dayOfWeek != DayOfWeek.Monday) {
                            laborDay = laborDay.AddDays(1);
                            dayOfWeek = laborDay.DayOfWeek;
                        }
                        return laborDay;
                    }
                case "TG": {
                        DateTime thanksgiving;
                        List<DateTime> thursdays = new List<DateTime>();
                        int day = 1;
                        while (day < 31) {
                            DateTime novemberDay = new DateTime(DateTime.Today.Year, 11, day);
                            if (novemberDay.DayOfWeek == DayOfWeek.Thursday) {
                                thursdays.Add(novemberDay);
                            }
                            day++;
                        }
                        thanksgiving = thursdays[3];
                        return thanksgiving;
                    }
                case "MLKJD": {
                        DateTime MLKDay = new DateTime(DateTime.Today.Year, 1, 21);
                        DayOfWeek dayOfWeek = MLKDay.DayOfWeek;
                        while (dayOfWeek != DayOfWeek.Monday) {
                            MLKDay = MLKDay.AddDays(-1);
                            dayOfWeek = MLKDay.DayOfWeek;
                        }
                        return MLKDay.Date;
                    }
                case "WB": {
                        DateTime PresDay = new DateTime(DateTime.Today.Year, 2, 21);
                        DayOfWeek dayOfWeek = PresDay.DayOfWeek;
                        while (dayOfWeek != DayOfWeek.Monday) {
                            PresDay = PresDay.AddDays(-1);
                            dayOfWeek = PresDay.DayOfWeek;
                        }
                        return PresDay.Date;
                    }
                case "CD": {
                        DateTime columbusDay;
                        List<DateTime> tuesday = new List<DateTime>();
                        int day = 1;
                        while (day < 31) {
                            DateTime octoberDay = new DateTime(DateTime.Today.Year, 10, day);
                            if (octoberDay.DayOfWeek == DayOfWeek.Tuesday) {
                                tuesday.Add(octoberDay);
                            }
                            day++;
                        }
                        columbusDay = tuesday[2];
                        return columbusDay;
                    }
                case "NYD": {
                        return new DateTime(DateTime.Now.Year + 1, 1, 1);
                    }
                case "JTTH": {
                        return new DateTime(DateTime.Now.Year, 6, 19);
                    }
                case "ID": {
                        return new DateTime(DateTime.Now.Year, 7, 4);
                    }
                case "CM": {
                        return new DateTime(DateTime.Now.Year, 12, 25);
                    }
                case "VD": {
                    return new DateTime(DateTime.Now.Year, 11, 11);
                }
                default:
                    return DateTime.Today;
            }
        }
    }
}
