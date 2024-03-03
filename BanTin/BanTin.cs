using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BanTin
{
    internal class BanTin : New
    {
        private string name { get; set; }
        private string noiDung { get; set; }
        private double time { get; set; }
        string categoryName { get; set; }
        private string authorName { get; set; }
        private List<string> listTime;
        private List<string> listChannels;
        private List<string> listDays;   


        public BanTin(string name, double time, string noiDung)
        {
            categoryName = " chua co du lieu the loai ";
            authorName = " chua co du lieu tac gia ";
            this.name = name;
            this.time = time;
            this.noiDung = noiDung;
            listTime = new List<string>();
            listChannels = new List<string>();
            listDays = new List<string>();
            New.getListNew().Add(this);
            
        }

        public List<string> getListTime()
        {
            return listTime;
        }

        public List<string> getListDays()
        {
            return listDays;
        }
        public List<string> getListChannels()
        {
            return listChannels;
        }

        public static List<New> getListNew()
        {
            return New.getListNew();
        }

        public void setCategoryName(string input)
        {
            categoryName = input;
        }

        public string getCategoryName()
        {
            foreach (var banTin in Category.getCategories())
            {
                if (banTin.name == this.name)
                {
                    categoryName = banTin.name;
                }
            }
            return categoryName;
        }

        public void setAuthorName(string input)
        {
            this.authorName = input;
        }

        public string getAuthorName()
        {
            return this.authorName;
        }

        public string getName()
        {
            return name;
        }

        public static void printAll()
        {
            foreach (var item in New.getListNew())
            {
                if (item is BanTin bantin)
                {
                    Console.WriteLine("Tên: " + bantin.name);
                    Console.WriteLine("Thời gian: " + bantin.time);
                    Console.WriteLine("Ten tac gia: " + bantin.authorName);
                    Console.WriteLine("The loai: " + bantin.categoryName);
                    Console.WriteLine();
                }
            }
        }

        public override string ToString()
        {
            return "Tên bản tin: " + name + "\n" +
                   "Nội dung: " + noiDung + "\n" +
                   "Thời lượng: " + time + "\n"; 
        }

    }
}


