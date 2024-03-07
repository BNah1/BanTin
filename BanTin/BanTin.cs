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
        private string name;
        private string noiDung { get; set; }
        private double time { get; set; }
        string categoryName { get; set; }
        private string authorName { get; set; }

        private List<string> listChannels;
        private List<string> listDays;
        private List<TimeSet> listTime;


        public BanTin(string name, double time, string noiDung)
        {
            categoryName = " chua co du lieu the loai ";
            authorName = " chua co du lieu tac gia ";
            this.name = name;
            this.time = time;
            this.noiDung = noiDung;
            listTime = new List<TimeSet>();
            listChannels = new List<string>();
            listDays = new List<string>();
            New.getListNew().Add(this);

        }

        public List<TimeSet> getListTime()
        {
            return listTime;
        }

        public double getTime() { return time; }

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
            foreach (Category iCategory in Category.getCategories())
            {
                if (iCategory.name == this.name)
                {
                    categoryName = iCategory.name;
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
            foreach (New item in New.getListNew())
            {
                if (item is BanTin bantin)
                {
                    Console.WriteLine("Tên: " + bantin.name);
                    Console.WriteLine("Thời gian: " + bantin.time);
                    Console.WriteLine("Ten tac gia: " + bantin.authorName);
                    Console.WriteLine("The loai: " + bantin.categoryName);
                    Console.WriteLine(" Các khoảng thời gian bản tin trình chiếu: ");
                }
            }
        }


        public void print()
        {
            Console.WriteLine("Tên bản tin: " + name + "\n" +
                   "Nội dung: " + noiDung);
            foreach (TimeSet item in listTime)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void addBanTinToCalendarDay(CalendarDay calendarDay, Channel channel, string period, int inputDay, int inputMonth)
        {
            setTime(period, channel.getName(), inputDay, inputMonth);
            calendarDay.addBanTinToChannel(this, channel, period);
        }
        public override string ToString()
        {
            return "Tên bản tin: " + name + "\n" +
                   "Nội dung: " + noiDung + "\n" +
                   "Thời lượng: " + time + "\n";
        }
        public void setTime(string period, string nameChannel, int inputDay, int inputMonth)
        {
            TimeSpan currentTime;

            if (period == "sang")
            {
                currentTime = new TimeSpan(8, 0, 0);
            }
            else if (period == "toi")
            {
                currentTime = new TimeSpan(18, 0, 0);
            }
            else
            {
                Console.WriteLine("Dữ liệu không đúng");
                return;
            }

            foreach (Calendar iCalendar in Calendar.getCanlendar2024())
            {
                if (iCalendar.getMonth() == inputMonth)
                {
                    foreach (CalendarDay iCalendarDay in iCalendar.getDays())
                    {
                        if (inputDay == iCalendarDay.getDay())
                        {
                            foreach (Channel iChannel in iCalendarDay.getListChannels())
                            {
                                if (iChannel.getName() == nameChannel)
                                {
                                    double xTime = 0;

                                    // Duyệt qua tất cả các phần tử New trong ListPeriod
                                    foreach (New newElement in iChannel.getListPeriod(period))
                                    {
                                        // Kiểm tra xem New hiện tại có phải là New đang được xử lý không
                                        if (newElement == this)
                                        {
                                            break; // Dừng duyệt khi bạn đến New hiện tại
                                        }

                                        // Cộng dồn thời gian từ các New trước đó
                                        xTime += newElement.getTime();
                                    }

                                    // Khởi tạo TimeSet
                                    TimeSet iTime = new TimeSet(time, period, nameChannel, this.name);
                                    iTime.setChannelOfTimeSet(nameChannel);
                                    iTime.setBanTinOfTimeSet(this.name);
                                    iTime.setDayOfTimeSet(inputDay + "/" + inputMonth + "/" + "2024");

                                    // Điều chỉnh currentTime dựa trên xTime đã tích lũy
                                    TimeSpan xtimeToAdd = TimeSpan.FromSeconds(xTime);
                                    currentTime = currentTime.Add(xtimeToAdd);
                                    // Tạo timeStart cho New
                                    DateTime iTimeStart = new DateTime(
                                        iCalendarDay.Calendar.getYear(),
                                        iCalendarDay.Calendar.getMonth(),
                                        iCalendarDay.getDay()
                                    ).Add(currentTime);

                                    iTime.setTimeStart(iTimeStart);
                                    this.listTime.Add(iTime);
                                }
                            }
                        }
                    }
                }
            }
        }

        //public void setTime(string period, string nameChannel, int inputDay, int inputMonth)
        //{
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
        //        Console.WriteLine("Dữ liệu không đúng");
        //        return;
        //    }

        //    foreach (Calendar iCalendar in Calendar.getCanlendar2024())
        //    {
        //        if (iCalendar.getMonth() == inputMonth)
        //        {
        //            foreach (CalendarDay iCalendarDay in iCalendar.getDays())
        //            {
        //                if (inputDay == iCalendarDay.getDay())
        //                {
        //                    foreach (Channel iChannel in iCalendarDay.getListChannels())
        //                    {
        //                        if (iChannel.getName() == nameChannel)
        //                        {
        //                            double xTime = 0;

        //                            // Duyệt qua tất cả các phần tử New trong ListPeriod
        //                            foreach (New newElement in iChannel.getListPeriod(period))
        //                            {
        //                                // Kiểm tra xem New hiện tại có phải là New đang được xử lý không
        //                                if (newElement == this)
        //                                {
        //                                    break; // Dừng duyệt khi bạn đến New hiện tại
        //                                }

        //                                // Cộng dồn thời gian từ các New trước đó
        //                                xTime += newElement.getTime();
        //                            }

        //                            // Khởi tạo TimeSet
        //                            TimeSet iTime = new TimeSet(time, period, nameChannel, this.name);
        //                            iTime.setChannelOfTimeSet(nameChannel);
        //                            iTime.setBanTinOfTimeSet(this.name);
        //                            iTime.setDayOfTimeSet(inputDay + "/" + inputMonth + "/" + "2024");

        //                            // Điều chỉnh currentTime dựa trên xTime đã tích lũy
        //                            TimeSpan xtimeToAdd = TimeSpan.FromSeconds(xTime);
        //                            currentTime = currentTime.Add(xtimeToAdd);
        //                            // Tạo timeStart cho New
        //                            DateTime iTimeStart = new DateTime(
        //                                iCalendarDay.Calendar.getYear(),
        //                                iCalendarDay.Calendar.getMonth(),
        //                                iCalendarDay.getDay()
        //                            ).Add(currentTime);

        //                            iTime.setTimeStart(iTimeStart);
        //                            this.listTime.Add(iTime);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}





    }
}





