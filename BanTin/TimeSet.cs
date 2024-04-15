using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BanTin
{
    public class TimeSet
    {

        private double time;
        private string period;
        private string nameChannel;
        private string nameBanTin;
        private int day;
        private int month;
        private DateTime timeStart;
        private string calendarShow;
        public static List<TimeSet> listAllTimeSet = new List<TimeSet>();
        private TimeSpan timeEnd { get; set; }
        public string Period { get => period; set => period = value; }
        public string NameChannel { get => nameChannel; set => nameChannel = value; }
        public string NameBanTin { get => nameBanTin; set => nameBanTin = value; }
        public int Day { get => day; set => day = value; }

        public TimeSet(double time, string period, int day, int month, string nameChannel, string nameBanTin)
        {
            this.day = day;
            this.month = month;
            this.time = time;
            this.period = period;
            this.nameChannel = nameChannel;
            this.nameBanTin = nameBanTin;
            listAllTimeSet.Add(this);
            calendarShow = day + "/" + month;
        }
        public void setTime(double input) { this.time = input; }
        public double getTime() { return time; }
        public void setTimeStart(DateTime input)
        {
            timeStart = input;
        }
        public int getDay() { return day; }
        public int getMonth() { return month; }
        public void setChannelOfTimeSet(string input)
        {
            nameChannel = input;
        }
        public string getChannelOfTimeSet()
        {
            return nameChannel;
        }
        public void setBanTinOfTimeSet(string input)
        {
            nameBanTin = input;
        }
        public void setDayOfTimeSet(string input)
        {
            calendarShow = input;
        }
        public DateTime getTimeStart()
        {
            return timeStart;
        }

        public override string ToString()
        {
            return "Thoi luong: " + time + "s" + "\n" +
                   "Khung chieu: " + period + "\n" +
                   "Thời gian bat dau: " + timeStart + " tại kênh " + nameChannel;
        }

    }
}
