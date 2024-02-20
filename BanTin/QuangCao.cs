﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class QuangCao : SetTimeStart
    {
        private string name { get; set; }
        private double time { get; set; }
        private string noidung { get; set; }
        DateTime timeStart { get; set; }
        public QuangCao(string name, double time, string noidung)
        {
            this.name = name;
            this.noidung = noidung;

            if (time <= 60)
                this.time = time;
            else
                Console.WriteLine("thoi luong quang cao khong duoc qua 60s");

        }

        public DateTime setTimeStart(string timeS)
        {
            timeStart = DateTime.ParseExact(timeS, "H:mm:ss", null);
            return timeStart;
        }

    }
}
