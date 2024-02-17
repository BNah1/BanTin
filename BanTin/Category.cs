using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Category : BanTinManager
    {
        public string name { get; set; }
        public List<BanTin> news { get; set; }

        public Category() {
            this.name = name;
            this.news = new List<BanTin>();
        }

        public void addCategory(BanTin banTinDaTao) {
            news.Add(banTinDaTao);
        }

        public void removeCategory(BanTin banTinDaTao)
        {
            news.Remove(banTinDaTao);
        }

        public override void printInfo() {
            foreach (var banTin in news)
            {
                Console.WriteLine(banTin.ToString());
            }
                
         }

    }
}
