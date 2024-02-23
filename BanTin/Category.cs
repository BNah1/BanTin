using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Category 
    {
        private static int i = 1;
        public string name { get; set; }
        public List<BanTin> news { get; set; }
        public static List<Category> categories { get; set; }

        public Category( string name) {
            this.name = name;
            this.news = new List<BanTin>();
            if (categories == null)
            {
                categories = new List<Category>();
            }
            categories.Add(this);
        }

        public void setCategory(BanTin banTinDaTao) {
            news.Add(banTinDaTao);
            banTinDaTao.getCategoryName(this.name);
        }

        public void removeCategory(BanTin banTinDaTao)
        {
            news.Remove(banTinDaTao);
        }

        public void getName()
        {
            Console.WriteLine("The loai "+ i +" : "+ name);
            i++;
        }
        static public void printAllCategory()
        {
            foreach (var category in categories)
            {
                category.getName();
            }
        }

        public void printAllBanTin() {
            if (news == null)
                Console.WriteLine("khong co du lieu");
            else          
            foreach (var banTin in news)
            {
                banTin.getName();               
            }                
         }

    }
}
