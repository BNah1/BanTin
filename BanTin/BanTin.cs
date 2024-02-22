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
        private DateTime timeStart { get; set; } = DateTime.MinValue.Date; 
        private DateTime timeEnd { get; set; }
        public Category belongstoCategory { get; set; }
        public Author belongstoAuthor { get; set; }
        public static List<BanTin> listBanTins = new List<BanTin>();


        public BanTin(string name, double time, string noiDung, string timeStart, string timeEnd, Category belongstoCategory, Author belongstoAuthor)
        {
            this.name = name;
            this.time = time;
            this.noiDung = noiDung;
            this.belongstoCategory = belongstoCategory;
            belongstoCategory.setCategory(this);
            this.belongstoAuthor = belongstoAuthor;
            belongstoAuthor.setAuthor(this);
            listBanTins.Add(this);

            
        }

        public void getName() {
            Console.WriteLine("Ban Tin : " + name);
        }
 
        public static void printAll()
        {
            foreach (BanTin bantin in listBanTins)
            {
                Console.WriteLine("Tên: " + bantin.name);
                Console.WriteLine("Thời gian: " + bantin.time);
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return "Tên bản tin: " + name + "\n" +
                   "Nội dung: " + noiDung + "\n" +
                   "Thời lượng: " + time + "\n"; 
        }

        public DateTime setTimeStart(string timeString) {
            timeStart = DateTime.ParseExact(timeString, "H:mm:ss", null);
            TimeSpan duration = TimeSpan.FromSeconds(time);
            timeEnd = timeStart.Add(duration);
            return timeStart;
        }

    }
}


