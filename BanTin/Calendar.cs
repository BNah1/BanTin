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
        private List<DateTime> days;

        public Calendar(int year, int month)
        {
            this.year = year;
            this.month = month;
            this.days = GenerateCalendarDays(year, month);
        }

        public List<DateTime> GetDays()
        {
            return days;
        }

        private List<DateTime> GenerateCalendarDays(int year, int month)
        {
            List<DateTime> calendarDays = new List<DateTime>();

            // Tạo một DateTime đại diện cho ngày đầu tiên của tháng
            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            // Tạo một DateTime đại diện cho ngày cuối cùng của tháng
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Lặp qua tất cả các ngày từ ngày đầu tiên đến ngày cuối cùng của tháng và thêm vào danh sách
            for (DateTime currentDate = firstDayOfMonth; currentDate <= lastDayOfMonth; currentDate = currentDate.AddDays(1))
            {
                calendarDays.Add(currentDate);
            }

            return calendarDays;
        }
    }
}
