using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Category : ShowBanTin
    {
        public string name { get; set; }
        public List<BanTin> news { get; set; }

        public Category() {
            this.name = name;
            this.news = new List<BanTin>();
        }

        public void setCategory(BanTin banTinDaTao) {
            news.Add(banTinDaTao);
        }

        public void removeCategory(BanTin banTinDaTao)
        {
            news.Remove(banTinDaTao);
        }

        public void printAll() {
            foreach (var banTin in news)
            {
                banTin.getName();
            }                
         }

    }
}
