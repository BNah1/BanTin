using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class LiveStream : New
    {

        private string name { get; set; }
        private double time { get; set; }
        private string noidung { get; set; }
        private string reporterName { get; set; }
        private List<string> listChannels;
        private List<string> listDays;
        private List<DateTime> listTime;

        public LiveStream(string name, double time, string noidung)
        {
            this.reporterName = " chua co du lieu phong vien ";
            this.name = name;
            this.noidung = noidung;
            if (time <= 60)
                this.time = time;
            else
                Console.WriteLine("thoi luong quang cao khong duoc qua 60s");
            New.getList().Add(this);
        }

        public List<string> getListChannels()
        {
            return listChannels;
        }

        public List<string> getListDays()
        {
            return listDays;
        }

        public static List<New> getListNew()
        {
            return New.getList();
        }


    }
}
