using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class TimeSet
    {

        private double time;
        private string period;
        private string nameChannel;
        private string nameBanTin;
        private DateTime timeStart;
        private DateTime timeEnd { get; set; }
        public TimeSet(double time, string period, string nameChannel, string nameBanTin)
        {
            this.time = time;
            this.period = period;
            this.nameChannel = nameChannel;
            this.nameBanTin = nameBanTin;
        }  


        public DateTime setTimeStart(string timeString)
        {
            timeStart = DateTime.ParseExact(timeString, "H:mm:ss", null);
            TimeSpan duration = TimeSpan.FromSeconds(time);
            timeEnd = timeStart.Add(duration);
            return timeStart;
        }



        //public void setTimePeriod(string period)
        //{
        //    if (period == "sang")
        //    {
        //        timeStart = timeStartMorning;
        //        TimeSpan duration1 = TimeSpan.FromSeconds(time);
        //        timeEnd = timeStart.Add(duration1);
        //    }
        //    else if (period == "toi")
        //    {
        //        timeStart = timeStartNight;
        //        TimeSpan duration2 = TimeSpan.FromSeconds(time);
        //        timeEnd = timeStart.Add(duration2);
        //    }
        //    else
        //    {
        //        timeStart = DateTime.MinValue;
        //        TimeSpan duration1 = TimeSpan.FromSeconds(time);
        //        timeEnd = timeStart.Add(duration1);
        //    }
        //}
    }
}
