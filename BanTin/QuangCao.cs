using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class QuangCao : BanTin , New 
    {

        private string name { get; set; }
        private double time { get; set; }
        private string noidung { get; set; }
        private List<string> listChannels;
        private List<string> listDays;
        private List<TimeSet> listTime;

        public QuangCao(string name, double time, string noidung) : base(name, time, noidung)
        {
            this.name = name;
            this.noidung = noidung;
            if (time <= 60)
                this.time = time;
            else
                Console.WriteLine("thoi luong quang cao khong duoc qua 60s");
            New.getListNew().Add(this);
            listTime = new List<TimeSet>();
            listChannels = new List<string>();
            listDays = new List<string>();
        }
        public List<string> getListChannels()
        {
            return listChannels;
        }

        public List<string> getListDays()
        {
            return listDays;
        }
        public double getTime() { return time; }
        public static List<New> getListNew()
        {
            return New.getListNew();
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

        //public DateTime setTimeStart(string timeS)
        //{
        //    timeStart = DateTime.ParseExact(timeS, "H:mm:ss", null);
        //    TimeSpan duration = TimeSpan.FromSeconds(time);
        //    timeEnd = timeStart.Add(duration);
        //    return timeStart;
        //}

        public static void printAll()
        {
            foreach (New item in New.getListNew())
            {   
                if (item is QuangCao qc)
                {
                    Console.WriteLine("Tên: " + qc.name);
                    Console.WriteLine("Thời gian: " + qc.time);
                    Console.WriteLine();
                }
            }
        }
    }
}
