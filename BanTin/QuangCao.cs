using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class QuangCao : BanTin
    {
        public QuangCao(string name, double time, string noiDung, string timeStart, string timeEnd)
        {
            this.name = name;
            this.time = time;
            this.noiDung = noiDung;
            this.timeStart = timeStart;
        }

        public override void printInfo()
        {
            Console.WriteLine("Quảng cáo: " + name);
            Console.WriteLine("Nội dung: " + noiDung);
            Console.WriteLine("Thời lượng: " + time);
            Console.WriteLine("Bắt đầu vào: " + timeStart);
        }

        public static void printAll(List<BanTin> listBanTins)
        {
            foreach (BanTin bantin in listBanTins)
            {
                if (bantin is QuangCao quangCao)
                {
                    Console.WriteLine("Tên: " + quangCao.name);
                    Console.WriteLine("Thời gian: " + quangCao.time);
                    Console.WriteLine("Thời gian bắt đầu: " + quangCao.timeStart);
                    Console.WriteLine();
                }
            }
        }

    }
}
