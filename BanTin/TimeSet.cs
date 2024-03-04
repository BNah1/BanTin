using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BanTin
{
    internal class TimeSet
    {

        private double time;
        private string period;
        private string nameChannel;
        private string nameBanTin;
        private string day;
        private DateTime timeStart;
        private DateTime timeEnd { get; set; }
        public TimeSet(double time, string period, string nameChannel, string nameBanTin)
        {
            this.time = time;
            this.period = period;
            this.nameChannel = nameChannel;
            this.nameBanTin = nameBanTin;
        }

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
            day = input;
        }
        public DateTime getTimeStart()
        {
            return timeStart;
        }

        public override string ToString()
        {
            return "Thoi luong: " + time +"s"+  "\n" +
                   "Khung chieu: " + period + "\n" +
                   "Thời gian bat dau: " + timeStart + "\n" +
                   "Thời gian chiếu " + day + "\n";
        }

        public void setTimeStart(string timeString)
        {
            timeStart = DateTime.ParseExact(timeString, "H:mm:ss", null);
            TimeSpan duration = TimeSpan.FromSeconds(time);
            timeEnd = timeStart.Add(duration);
        }

       
    }
}
