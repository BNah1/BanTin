using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Calendar
    {
        private int year;
        private int month;
        private int day;
        private List<CalendarDay> days;

        public Calendar(int year, int month)
        {
            this.year = year;
            this.month = month;
            this.days = GenerateCalendarDays(year, month);
        }

        public List<CalendarDay> GetDays()
        {
            return days;
        }

        public int getYear() { 
            return year;
        }
        public int getMonth()
        {
            return month;
        }


        private List<CalendarDay> GenerateCalendarDays(int year, int month)
        {
            List<CalendarDay> calendarDays = new List<CalendarDay>();

            // Tạo một DateTime đại diện cho ngày đầu tiên của tháng
            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            // Tạo một DateTime đại diện cho ngày cuối cùng của tháng
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Lặp qua tất cả các ngày từ ngày đầu tiên đến ngày cuối cùng của tháng và thêm vào danh sách
            for (DateTime currentDate = firstDayOfMonth; currentDate <= lastDayOfMonth; currentDate = currentDate.AddDays(1))
            {
                // Tạo một đối tượng CalendarDay mới với giá trị ngày và tham chiếu tới đối tượng Calendar gốc
                CalendarDay calendarDay = new CalendarDay(currentDate.Day, this);
                calendarDays.Add(calendarDay);
            }

            return calendarDays;
        }

    }
}
