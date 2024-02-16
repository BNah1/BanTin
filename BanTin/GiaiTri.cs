using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class GiaiTri : BanTin
    {
        public GiaiTri(string name, double time, string noiDung, string timeStart, string timeEnd)
        {
            this.name = name;
            this.time = time;
            this.noiDung = noiDung;
            this.timeStart = timeStart;
            this.timeEnd = timeEnd;
        }

        public override void printInfo()
        {
            Console.WriteLine("Tên bản tin: " + name);
            Console.WriteLine("Nội dung: " + noiDung);
            Console.WriteLine("Thời lượng: " + time);
            Console.WriteLine("Bắt đầu vào: " + timeStart);
            Console.WriteLine("Bắt đầu vào: " + timeEnd);
        }
 
        public static double calculateTime(BanTin[] listBanTins)
        {
            double totalTime = 0;
            foreach (BanTin bantin in listBanTins)
            {
                if (bantin is GiaiTri giaiTri)
                {
                    totalTime += giaiTri.time; // Truy cập thuộc tính Time của lớp con GiaiTri
                }
            }
            return totalTime;
        }
    }
}
