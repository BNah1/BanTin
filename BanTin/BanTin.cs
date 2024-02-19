using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class BanTin : BanTinManager
    {
        private string name { get; set; }
        private string noiDung { get; set; }
        private string timeStart { get; set; }
        private double time { get; set; }
        public Category belongstoCategory { get; set; }
        public Author belongstoAuthor { get; set; }


        public BanTin(string name, double time, string noiDung, string timeStart, string timeEnd, Category belongstoCategory, Author belongstoAuthor)
        {
            this.name = name;
            this.time = time;
            this.noiDung = noiDung;
            this.timeStart = timeStart;
            this.belongstoCategory = belongstoCategory;
            belongstoCategory.setCategory(this);
            this.belongstoAuthor = belongstoAuthor;
            belongstoAuthor.setAuthor(this);
        }

        public override void printInfo()
        {
            Console.WriteLine("Tên bản tin: " + name);
            Console.WriteLine("Nội dung: " + noiDung);
            Console.WriteLine("Thời lượng: " + time);
            Console.WriteLine("Bắt đầu vào: " + timeStart);
        }

        public static void printAll(List<BanTinManager> listBanTins)
        {
            foreach (BanTinManager bantin in listBanTins)
            {
                if (bantin is BanTin banTin)
                {
                    Console.WriteLine("Tên: " + banTin.name);
                    Console.WriteLine("Thời gian: " + banTin.time);
                    Console.WriteLine("Thời gian bắt đầu: " + banTin.timeStart);
                    Console.WriteLine();
                }
            }
        }

        public override string ToString()
        {
            return "Tên bản tin: " + name + "\n" +
                   "Nội dung: " + noiDung + "\n" +
                   "Thời lượng: " + time + "\n" +
                   "Bắt đầu vào: " + timeStart;
        }

        public static double calculateTime(BanTinManager[] listBanTins)
        {
            double totalTime = 0;
            foreach (BanTinManager bantin in listBanTins)
            {
                if (bantin is BanTin banTin)
                {
                    totalTime += banTin.time; // Truy cập thuộc tính Time của lớp con banTin
                }
            }
            return totalTime;
        }


    }
}
