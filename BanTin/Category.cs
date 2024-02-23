using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Category 
    {
        public string name { get; set; }
        public List<BanTin> news { get; set; }
        public static List<Category> categories { get; set; }

        public Category( string name) {
            this.name = name;
            this.news = new List<BanTin>();
            categories = new List<Category>();
        }

        public void setCategory(BanTin banTinDaTao) {
            news.Add(banTinDaTao);
        }

        public void removeCategory(BanTin banTinDaTao)
        {
            news.Remove(banTinDaTao);
        }

        public void getName()
        {
            Console.WriteLine("Category : " + name);
        }
        static public void printAllCategory()
        {
            foreach (var category in categories)
            {
                category.getName();
            }
        }

        public void printAllBanTin() {
            foreach (var banTin in news)
            {
                banTin.getName();
            }                
         }

    }
}
