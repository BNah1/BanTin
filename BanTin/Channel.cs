using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Channel : ShowBanTin
    {
        private string name;
        private int limitNews;
        private List<BanTin> sang;
        private List<BanTin> toi;
        private Schedule schedule;

    public static List<Channel> chanels { get; set; }
        public Channel(string name, int limitNews)
        {
            
                

            this.name = name;
            if (limitNews < 10 && limitNews > 3)
                this.limitNews = limitNews;
            else
                Console.WriteLine("So luong ban tin toi da cho 1 kenh la 10 va toi thieu la 3 ");

            if (chanels == null)
                chanels = new List<Channel>();
            else
                chanels.Add(this);
        }

        public void channelAddBanTin(BanTin banTinDaTao, string period) {
            if (period == "sang")
            {
                if (sang == null)
                {
                    sang = new List<BanTin>();
                    sang.Add(banTinDaTao);
                }
                else
                    sang.Add(banTinDaTao);

            }
            else if (period == "toi")
            {
                if (toi == null)
                {
                    toi = new List<BanTin>();
                    toi.Add(banTinDaTao);
                }
                else
                    toi.Add(banTinDaTao);
            }
            else
            {
                Console.WriteLine("Lam on nhap lai");
                return;
            }

        }

        public void printAll()
        {
            Console.WriteLine("Kenh " + name + " gom cac ban tin :");
            Console.WriteLine("Ban tin buoi sang: ");
            if(sang == null)
                Console.WriteLine("khong co ban tin buoi sang ");
            else
            {
                foreach (var banTin in sang)
                    banTin.getName();
            }

            Console.WriteLine("Ban tin buoi toi: ");
            if (toi == null)
                Console.WriteLine("khong co ban tin buoi toi ");
            else
            {
                foreach (var banTin in toi)
                    banTin.getName();
            }
        }


    }
}
