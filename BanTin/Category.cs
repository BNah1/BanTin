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
        private List<BanTin> news { get; set; }
        private static List<Category> categories { get; set; }


        public Category(string name)
        {
            this.name = name;
            //kiem tra list BanTin
            if (news == null)
                news = new List<BanTin>();

            if (categories == null)
            {
                categories = new List<Category>();
                categories.Add(this);
            }
            categories.Add(this);
        }

        public List<BanTin> getNews()
        {
            if (news == null)
            {
                news = new List<BanTin>();
            }
            return news;
        }
        public static List<Category> getCategories()
        {
            if (categories == null)
            {
                categories = new List<Category>();
            }
            return categories;
        }



        public void printAllBanTin()
        {
            Console.WriteLine("The loai " + name + " gom cac ban tin :");
            if (news == null || news.Count == 0)
                Console.WriteLine("khong co du lieu");
            else
                foreach (var banTin in news)
                {
                    Console.WriteLine(banTin.getName());
                }
        }



        public void setCategory(string banTinName)
        {
            bool check = false;
            BanTin foundBanTin = null;
            foreach (var banTin in BanTin.getListBanTins())
            {
                if (banTin.getName() == banTinName)
                {
                    check = true;
                    foundBanTin = banTin;
                    break;
                }
            }
            if (check && foundBanTin != null)
            {
                news.Add(foundBanTin);
                foundBanTin.setCategoryName(this.name);
            }

        }

        public void removeCategory(string banTinName)
        {
            foreach (var banTin in BanTin.getListBanTins())
            {
                if (banTin.getName() == banTinName)
                {
                    news.Remove(banTin);
                    break;
                }
            }
        }


        static public void printAllCategory()
        {
            foreach (var category in categories)
            {
                Console.WriteLine("The loai " + i + " : " + category.name);
                i++;
            }
        }



    }
}
