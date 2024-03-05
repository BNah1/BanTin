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
            foreach (TimeSet item in listTime)
            {
                Console.WriteLine(item.ToString());
            }
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
                Console.WriteLine("Du lieu khong dung");
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
                                    iChannel.getListPeriod(period).Add(this);
                                    int index = iChannel.getListPeriod(period).IndexOf(this); // Lấy chỉ mục của tin tức trong danh sách
                                    if (index > 0)
                                    {
                                        TimeSpan timeToAdd = TimeSpan.FromSeconds(index);
                                        currentTime = currentTime.Add(timeToAdd);
                                    }
                                    TimeSet iTime = new TimeSet(time, period, nameChannel, this.name);
                                    this.listTime.Add(iTime);
                                    iTime.setChannelOfTimeSet(nameChannel);
                                    iTime.setBanTinOfTimeSet(this.name);
                                    iTime.setDayOfTimeSet(inputDay + "/" + inputMonth + "/" + "2024");
                                    // đặt timeStart cho class TimeSet
                                    DateTime iTimeStart;
                                    iTimeStart = new DateTime(iCalendarDay.Calendar.getYear(), iCalendarDay.Calendar.getMonth(), iCalendarDay.getDay())
                                        .Add(currentTime)
                                        .AddSeconds(this.time);
                                    iTime.setTimeStart(iTimeStart);

                                }
                                else
                                {
                                    Console.WriteLine("Khong co du lieu kenh hoac kenh chua duoc tao");
                                    return;
                                }
                            }
                        }
                    }
                }
            }

        }

    //    public void SetTime(string period, string nameChannel, int inputDay, int inputMonth)
    //    {
    //        Dictionary<string, TimeSpan> periodMap = new Dictionary<string, TimeSpan>
    //{
    //    { "sang", new TimeSpan(8, 0, 0) },
    //    { "toi", new TimeSpan(18, 0, 0) }
    //};

    //        if (!periodMap.ContainsKey(period))
    //        {
    //            Console.WriteLine("Du lieu khong dung");
    //            return;
    //        }

    //        var calendar2024 = Calendar.getCanlendar2024();
    //        var selectedCalendar = calendar2024.FirstOrDefault(c => c.getMonth() == inputMonth);

    //        if (selectedCalendar != null)
    //        {
    //            var selectedDay = selectedCalendar.getDays().FirstOrDefault(d => d.getDay() == inputDay);

    //            if (selectedDay != null)
    //            {
    //                var selectedChannel = selectedDay.getListChannels().FirstOrDefault(c => c.getName() == nameChannel);

    //                if (selectedChannel != null)
    //                {
    //                    selectedChannel.getListPeriod(period).Add(this);

    //                    int index = selectedChannel.getListPeriod(period).IndexOf(this);
    //                    if (index > 0)
    //                    {
    //                        periodMap[period] = periodMap[period].Add(TimeSpan.FromSeconds(index));
    //                    }

    //                    var timeSet = new TimeSet(time, period, nameChannel, this.name);
    //                    this.listTime.Add(timeSet);
    //                    timeSet.setChannelOfTimeSet(nameChannel);
    //                    timeSet.setBanTinOfTimeSet(this.name);
    //                    timeSet.setDayOfTimeSet($"{inputDay}/{inputMonth}/2024");

    //                    DateTime timeStart = new DateTime(selectedCalendar.getYear(), selectedCalendar.getMonth(), selectedDay.getDay())
    //                        .Add(periodMap[period])
    //                        .AddSeconds(this.time);

    //                    timeSet.setTimeStart(timeStart);
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Khong co du lieu kenh hoac kenh chua duoc tao");
    //                }
    //            }
    //        }
    //    }

    }
}





