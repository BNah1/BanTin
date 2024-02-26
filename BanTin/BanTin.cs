using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BanTin
{
    internal class BanTin : SetTimeStart
    {
        private string name { get; set; }
        private string noiDung { get; set; }
        private double time { get; set; }
        private DateTime timeEnd { get; set; }
        private DateTime timeStart { get; set; }
        private DateTime timeStartMorning { get; set; } = DateTime.Today + new TimeSpan(7, 0, 0);
        private DateTime timeStartNight { get; set; } = DateTime.Today + new TimeSpan(18, 0, 0);
        private string categoryName { get; set; }
        private string chanelName { get; set; }
        private string authorName { get; set; }
        private static List<BanTin> listBanTins = new List<BanTin>();
        private List<string> listChanels = new List<string>();

        public BanTin(string name, double time, string noiDung)
        {
            categoryName = " Chua dat the loai ";
            authorName = " Chua dat ten tac gia ";
            this.name = name;
            this.time = time;
            this.noiDung = noiDung;

            if (listBanTins == null)
            {
                listBanTins = new List<BanTin>();
            }
            listBanTins.Add(this);
        }

        public List<string> getListChanels() { 
            return listChanels;
        }

        public static List<BanTin> getListBanTins()
        {
            return BanTin.listBanTins;
        }

        public string getChanelName() {
            return chanelName;
        }


        public string  getCategoryName()
        {
            foreach (var banTin in Category.getCategories())
            {
                if (banTin.name == this.name)
                {
                    categoryName = banTin.name;
                }
            }
            return categoryName;
        }

        public void getAuthorName(string authorName)
        {
            this.authorName = authorName;
        }
        public string getName()
        {
            return name;
        }

        public static void printAll()
        {
            foreach (BanTin bantin in listBanTins)
            {
                Console.WriteLine("Tên: " + bantin.name);
                Console.WriteLine("Thời gian: " + bantin.time);
                Console.WriteLine("Ten tac gia: " + bantin.authorName);
                Console.WriteLine("The loai: " + bantin.categoryName);
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return "Tên bản tin: " + name + "\n" +
                   "Nội dung: " + noiDung + "\n" +
                   "Thời lượng: " + time + "\n" +
                   "Bắt đầu vào: " + timeStart + "\n";
        }

        public DateTime setTimeStart(string timeString)
        {
            timeStart = DateTime.ParseExact(timeString, "H:mm:ss", null);
            TimeSpan duration = TimeSpan.FromSeconds(time);
            timeEnd = timeStart.Add(duration);
            return timeStart;
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

    }
}


