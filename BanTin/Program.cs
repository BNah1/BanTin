using System;
using System.Collections.Generic;
using BanTin;

namespace BanTin
{   

    class Program
    {
        static void Main(string[] args)
        {
            Category thethao = new Category();
            Category giaitri = new Category();
            Category thoisu = new Category();
            Category dubaothoitiet = new Category();

            List<BanTinManager> danhSachBantin = new List<BanTinManager>();

            BanTin banTin1 = new BanTin("Bản tin 1", 10.5, "Nội dung bản tin 1", "08:00", "08:10", thethao);
            danhSachBantin.Add(banTin1);

            BanTin banTin2 = new BanTin("Bản tin 1", 10.5, "Nội dung bản tin 1", "08:00", "08:10", dubaothoitiet);
            danhSachBantin.Add(banTin2);

            BanTin banTin3 = new BanTin("Bản tin 1", 10.5, "Nội dung bản tin 1", "08:00", "08:10", thoisu);
            danhSachBantin.Add(banTin3);

            BanTin banTin4 = new BanTin("Bản tin 1", 10.5, "Nội dung bản tin 1", "08:00", "08:10", thethao);
            danhSachBantin.Add(banTin4);

            BanTin banTin5 = new BanTin("Bản tin 1", 10.5, "Nội dung bản tin 1", "08:00", "08:10", giaitri);
            danhSachBantin.Add(banTin5);

            double tongTime = BanTin.calculateTime(danhSachBantin.ToArray());
            BanTin.printAll(danhSachBantin);

            giaitri.removeCategory(banTin5);
            giaitri.printInfo();
            thethao.printInfo();

            Console.WriteLine(tongTime); // In ra tổng thời gian: 22.7
        }
    }
}
