using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Schedule
    {
        private string day;
        private string month;

        public Schedule(string day, string month)
        {
            this.day = day;
            this.month = month;
        }

        public void ShowSchedule()
        {
            //Console.WriteLine("Lich trinh ngay " + day + "/" + month + ":");

            //// Kiểm tra và in bản tin sang của tất cả các kênh
            //foreach (var banTin in sang)
            //{
            //    Console.WriteLine("Bản tin sáng:");
            //    banTin.getName();
            //}

            //// Kiểm tra và in bản tin tối của tất cả các kênh
            //foreach (var banTin in toi)
            //{
            //    Console.WriteLine("Bản tin tối:");
            //    banTin.getName();
            //}
        }

    }

}
