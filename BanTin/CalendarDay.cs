using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BanTin
{
    internal class CalendarDay
    {   
        public int Day { get; }
        public Calendar Calendar { get; }

        private List<Channel> listChannels;
        public CalendarDay(int day, Calendar calendar)
        {
            Day = day;
            Calendar = calendar;
            listChannels = new List<Channel>();
        }

        public List<Channel> getListChannels() {
            return listChannels;
        }

        public void printAll() {
            foreach (Channel channel in listChannels) {
                Console.WriteLine(channel.getName + " :");
                channel.printAll();
                Console.WriteLine(listChannels);
            }
            
        }

        public override string ToString()
        {
            return $"{Day}/{Calendar.getMonth()}/{Calendar.getYear()}";
        }

        //public override string ToString()
        //{
        //    return $"{Day}/{Calendar.getMonth}/{Calendar.getYear}";
        //}
    }
}
