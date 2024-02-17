using System;
using System.Collections.Generic;
using BanTin;

namespace BanTin
{   

    class Program
    {
        static void Main(string[] args)
        {
            List<BanTin> danhSachBantin = new List<BanTin>();

            GiaiTri bantin1 = new GiaiTri("Ban Tin 1", 11.5, "Noi dung 1", "Time Start 1", "Time End 1");
            danhSachBantin.Add(bantin1);

            GiaiTri bantin2 = new GiaiTri("Ban Tin 2", 5.0, "Noi dung 2", "Time Start 2", "Time End 2");
            danhSachBantin.Add(bantin2);

            GiaiTri bantin3 = new GiaiTri("Ban Tin 3", 7.2, "Noi dung 3", "Time Start 3", "Time End 3");
            danhSachBantin.Add(bantin3);

            double tongTime = GiaiTri.calculateTime(danhSachBantin.ToArray());
            GiaiTri.printAll(danhSachBantin);

            Console.WriteLine(tongTime); // In ra tổng thời gian: 22.7
        }
    }
}
