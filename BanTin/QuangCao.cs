using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class QuangCao : SetTimeStart
    {
        private string name { get; set; }
        private double time { get; set; }
        private string noidung { get; set; }
        private DateTime timeStart { get; set; }
        private DateTime timeStartMorning { get; set; } = DateTime.Today + new TimeSpan(7, 0, 0);
        private DateTime timeStartNight { get; set; } = DateTime.Today + new TimeSpan(18, 0, 0);
        private DateTime timeEnd { get; set; }
        public QuangCao(string name, double time, string noidung)
        {
            this.name = name;
            this.noidung = noidung;

            if (time <= 60)
                this.time = time;
            else
                Console.WriteLine("thoi luong quang cao khong duoc qua 60s");

        }

        public void setTimePeriod(string period)
        {
            if (period == "sang")
            {
                    timeStart = timeStartMorning;
                    TimeSpan duration1 = TimeSpan.FromSeconds(time);
                    timeEnd = timeStart.Add(duration1);  
            }
            else if (period == "toi")
            {
                    timeStart = timeStartNight;
                    TimeSpan duration2 = TimeSpan.FromSeconds(time);
                    timeEnd = timeStart.Add(duration2);
            }
            else
            {
                timeStart = DateTime.MinValue;
                TimeSpan duration1 = TimeSpan.FromSeconds(time);
                timeEnd = timeStart.Add(duration1);
            }
        }

        public DateTime setTimeStart(string timeS)
        {
            timeStart = DateTime.ParseExact(timeS, "H:mm:ss", null);
            TimeSpan duration = TimeSpan.FromSeconds(time);
            timeEnd = timeStart.Add(duration);
            return timeStart;
        }


    }
}
