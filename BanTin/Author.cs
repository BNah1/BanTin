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
        private List<BanTin> news { get; set; }
        private static List<Author> authors { get; set; }

        public Author(string name, string company, string email)
        {
            this.name = name;
            this.company = company;
            this.email = email;
            // xet so luong ban tin cua tac gia
            if (news != null)
                this.numOfNews = news.Count;
            else
                this.numOfNews = 0;
            // xet danh sach tat ca cac tac gia
            if (authors == null)
                authors = new List<Author>();
            else
                authors.Add(this);
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
        static public void printAllAuthor()
        {
            foreach (var author in authors)
            {
                author.getName();
            }
        }

        public List<BanTin> getNews()
        {
            if (news == null)
            {
                news = new List<BanTin>();
            }
            return news;
        }

        public static List<Author> getAuthors()
        {
            if (authors == null)
            {
                authors = new List<Author>();
            }
            return authors;
        }

        public void getName()
        {
            Console.WriteLine("Tác giả: " + name);
        }

        public void setAuthor(BanTin banTinDaTao)
        {
            news.Add(banTinDaTao);
            banTinDaTao.setAuthorName(this.name);
            numOfNews = news.Count;
        }


    }
}
