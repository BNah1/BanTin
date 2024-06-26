﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BanTin
{
    public class CalendarDay
    {
        public int Day { get; }
        public Calendar Calendar { get; set; }
        private List<Channel> listChannels;
        private List<TimeSet> listTimeSets;
        public CalendarDay(int day, Calendar calendar)
        {
            this.Day = day;
            Calendar = calendar;
            this.listChannels = new List<Channel>();
            this.listTimeSets = new List<TimeSet>();
        }

        public void setListChannels(List<Channel> input)
        {
            listChannels = input;
        }
        public List<Channel> getListChannels()
        {
            // Trả về bản sao của danh sách để ngăn chặn sự thay đổi từ bên ngoài
            return listChannels;
        }

        // Thêm bản tin vào kênh của CalendarDay

        public void addBanTinToChannel(BanTin banTin, Channel channel, string period, int day, int month)
        {
            channel.channelAddBanTin(banTin.getName(), period);
            listTimeSets.Add(new TimeSet(banTin.getTime(), period, day, month, channel.getName(), banTin.getName()));
        }


        public int getDay()
        {
            return Day;
        }



        public override string ToString()
        {
            return $"{Day}/{Calendar.getMonth()}/{Calendar.getYear()}";
        }

        //public override string ToString()
        //{
        //    return $"{Day}/{Calendar.getMonth}/{Calendar.getYear}";
        //}
    }
    //public void setTime(double time, string period, string nameChannel, string nameNew) {
    //    TimeSpan currentTime;

    //    if (period == "sang")
    //    {
    //        currentTime = new TimeSpan(8, 0, 0);
    //    }

    //    else if (period == "toi")
    //    {
    //        currentTime = new TimeSpan(18, 0, 0);
    //    }
    //    else
    //    {
    //        Console.WriteLine("Du lieu khong dung");
    //        return;
    //    }

    //    foreach (var iNew in New.getListNew()) {
    //        if (iNew.getName() == nameNew)
    //        {
    //            foreach (var channel in iNew.getListChannels())
    //            {
    //                if (nameChannel == channel)
    //                {
    //                    foreach (var iChannel in listChannels)
    //                    {
    //                        if (nameChannel == iChannel.getName())
    //                        {
    //                            iChannel.getListPeriod(period).Add(iNew);
    //                            int index = iChannel.getListPeriod(period).IndexOf(iNew); // Lấy chỉ mục của tin tức trong danh sách
    //                            if (index > 0)
    //                            {
    //                                TimeSpan timeToAdd = TimeSpan.FromSeconds(index);
    //                                currentTime = currentTime.Add(timeToAdd);
    //                            }
    //                            TimeSet iTime = new TimeSet(time, period, nameChannel, nameNew);
    //                            iTime.setTimeStart(currentTime.ToString());
    //                            iNew.getListTime().Add($"{this.Day}/{this.Calendar.getMonth()}/{this.Calendar.getYear()} - {period} - {currentTime.ToString(@"hh\:mm")}");
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine("Khong co du lieu kenh hoac kenh chua duoc tao");
    //                            return;
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Khong co du lieu kenh o trong ban tin");
    //                    return;
    //                }

    //            }
    //        }
    //        else {
    //            Console.WriteLine("Khong co du lieu ban tin hoac ban tin chua duoc tao");
    //            return;
    //        }

    //    }


    //}
}
