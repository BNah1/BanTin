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
        public List<string> getListChanels()
        {
            return null;
        }

        public static List<New> getList()
        {
            return listBanTins;
        }

        public string getName() {
            return null;
        }

        public void setChanelName(string input)
        { 
        }
    }
}
