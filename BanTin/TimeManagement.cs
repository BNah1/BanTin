using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class TimeManagement
    {
        private int totalTime;
        TimeSpan duration;
        public Channel nameOfChannel { get; set; }

        public TimeManagement(int totalTime, Channel nameOfChannel)
        {
            this.totalTime = totalTime;
            this.nameOfChannel = nameOfChannel;
        }



        //public static double calculateTime(BanTinManager[] listBanTins)
        //{
        //    double totalTime = 0;
        //    foreach (BanTinManager bantin in listBanTins)
        //    {
        //        if (bantin is BanTin banTin)
        //        {
        //            totalTime += banTin.time; // Truy cập thuộc tính Time của lớp con banTin
        //        }
        //    }
        //    return totalTime;
        //}
    }
}
