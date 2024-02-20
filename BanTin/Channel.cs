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
        public List<BanTin> news { get; set; }
        public Channel(string name, int limitNews)
        {
            this.news = new List<BanTin>();
            this.name = name;
            if (limitNews < 10 && limitNews > 3)
                this.limitNews = limitNews;
            else
                Console.WriteLine("So luong ban tin toi da cho 1 kenh la 10 va toi thieu la 3 ");
        }

        public void channelAddBanTin(BanTin banTinDaTao) {
            news.Add(banTinDaTao);
        }

        public void printAll()
        {
            Console.WriteLine("Kenh " + name + " gom cac ban tin :");
            foreach (var banTin in news)
            {
                banTin.getName();
            }
        }
    }
}
