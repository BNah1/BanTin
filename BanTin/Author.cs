using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Author : ShowBanTin
    {
        private string company;
        public string name;
        private string email;
        private int numOfNews;
        public List<BanTin> news { get; set; }
        public static List<Author> authors { get; set; }

        public Author(string name, string company, string email)
        {
            this.name = name;
            this.company = company;
            this.email = email;
            this.numOfNews = news.Count;
            authors = new List<Author>();
        }

        public void printAll()
        {
            Console.WriteLine("Tên tác giả: " + name);
            Console.WriteLine("Thuộc : " + company);
            Console.WriteLine("Email : " + email);
            Console.WriteLine("Số lượng bài báo : " + numOfNews);
            Console.WriteLine("Các bài báo của tác giả " + name + " :");
            foreach (var banTin in news)
            {
                Console.WriteLine(banTin.ToString());
            }
    }

        public Author()
        {
            this.name = name;
            this.news = new List<BanTin>();
        }

        public void setAuthor(BanTin banTinDaTao)
        {
            news.Add(banTinDaTao);
            numOfNews = news.Count;
        }


    }
}
