using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal interface New
    {
        private static List<New> listBanTins = new List<New>();

        public static List<New> getListNew()
        {
            return listBanTins;
        }
        public double getTime()
        {
            return 0;
        }
        public void setTime(string period, string nameChannel, int inputDay, int inputMonth)
        { }
            public void print() { }
            public List<string> getListDays()
        {
            return null;
        }
        public List<string> getListChannels()
        {
            return null;
        }
        public List<string> getListTime()
        {
            return null;
        }
        public string getName() {
            return null;
        }

        public void setChanelName(string input)
        { 
        }
    }
}
