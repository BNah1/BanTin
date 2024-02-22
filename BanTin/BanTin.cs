﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BanTin 
{
    internal class BanTin : SetTimeStart
    {
        private string name { get; set; }
        private string noiDung { get; set; }
        private double time { get; set; }
        private DateTime timeEnd { get; set; }
        private DateTime timeStart { get; set; }
        private DateTime timeStartMorning { get; set; } = DateTime.Today + new TimeSpan(7, 0, 0);
        private DateTime timeStartNight { get; set; } = DateTime.Today + new TimeSpan(18, 0, 0);
        public Category belongstoCategory { get; set; }
        public Author belongstoAuthor { get; set; }
        public static List<BanTin> listBanTins = new List<BanTin>();


        public BanTin(string name, double time, string noiDung, Category belongstoCategory, Author belongstoAuthor)
        {
            this.name = name;
            this.time = time;
            this.noiDung = noiDung;
            this.belongstoCategory = belongstoCategory;
            belongstoCategory.setCategory(this);
            this.belongstoAuthor = belongstoAuthor;
            belongstoAuthor.setAuthor(this);
            listBanTins.Add(this);

            
        }

        public void getName() {
            Console.WriteLine("Ban Tin : " + name);
        }
 
        public static void printAll()
        {
            foreach (BanTin bantin in listBanTins)
            {
                Console.WriteLine("Tên: " + bantin.name);
                Console.WriteLine("Thời gian: " + bantin.time);
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return "Tên bản tin: " + name + "\n" +
                   "Nội dung: " + noiDung + "\n" +
                   "Thời lượng: " + time + "\n" +
                   "Bắt đầu vào: " + timeStart + "\n"; 
        }

        public DateTime setTimeStart(string timeString) {
            timeStart = DateTime.ParseExact(timeString, "H:mm:ss", null);
            TimeSpan duration = TimeSpan.FromSeconds(time);
            timeEnd = timeStart.Add(duration);
            return timeStart;
        }

        public void setTimePeriod(string period)
        {
            if (period == "sang")
            {
                timeStart = timeStartMorning;
                TimeSpan duration1 = TimeSpan.FromSeconds(time);
                timeEnd = timeStart.Add(duration1);
            }
            else if (period == "toi")
            {
                timeStart = timeStartNight;
                TimeSpan duration2 = TimeSpan.FromSeconds(time);
                timeEnd = timeStart.Add(duration2);
            }
            else
            {
                timeStart = DateTime.MinValue;
                TimeSpan duration1 = TimeSpan.FromSeconds(time);
                timeEnd = timeStart.Add(duration1);
            }
        }

    }
}


