﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BanTin
{
    internal class PhuongThuc
    {
        // Hàm khởi tạo
        public static void createCalendar()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // tao lich cac ngay trong nam 2024
            List<Calendar> calendarOf2024 = new List<Calendar>();
            for (int i = 0; i < 12; i++)
            {
                Calendar calendar = new Calendar(2024, i + 1);
                calendarOf2024.Add(calendar);

                List<CalendarDay> days = calendar.getDays();
            }
        }



        public static void setTimeAndBanTinForChannel(string nameofChannel, string nameofnew, string period, int day, int month)
        {
            CalendarDay calendarDay = Calendar.getCalendarDay(day, month);
            if (calendarDay != null)
            {
                List<Channel> channels = calendarDay.getListChannels().ToList();
                foreach (Channel channel in channels)
                {
                    if (channel.getName() == nameofChannel)
                    {
                        List<New> news = New.listBanTins;
                        foreach (New newsItem in news)
                        {
                            if (nameofnew == newsItem.getName())
                            {
                                channel.setTimeAndAddBanTin(newsItem, period, day, month);
                                break;
                            }
                        }
                        break;
                    }
                }
                calendarDay.setListChannels(channels); // Cập nhật danh sách kênh trong calendarDay
            }
            else
            {
                // Xử lý trường hợp ngày không hợp lệ
                Console.WriteLine("Ngày không hợp lệ!");
            }
        }


        // Phương thức chức năng
        // Tạo mới 1 Channel ( đồng thời thêm vào các ngày luôn )
        public static void addChannel(string nameofChannel, int numberOfNews)
        {
            foreach (Calendar iCalendar in Calendar.getCanlendar2024())
            {
                foreach (CalendarDay calendarDay in iCalendar.getDays())
                {
                    calendarDay.getListChannels().Add(new Channel(nameofChannel, numberOfNews));
                }
            }
        }
        // Tạo mới 1 BanTin
        public static void QuanLiBanTin()
        {
            while (true)
            {
                Console.WriteLine("Quản lý bản tin: ");
                Console.WriteLine("1. Thêm bản tin");
                Console.WriteLine("2. Sửa bản tin");
                Console.WriteLine("3. Xóa bản tin");
                Console.WriteLine("4. Đặt thời gian chiếu");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (nhập số từ 0 đến 5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Bạn đã chọn Thêm bản tin");
                        nhapBanTin();
                        break;

                    case "2":
                        Console.WriteLine("Bạn đã chọn sửa bản tin");
                        suaBanTin();
                        break;

                    case "3":
                        Console.WriteLine("Bạn đã chọn sửa bản tin");
                        suaBanTin();
                        break;

                    case "4":
                        Console.WriteLine("Nhập tên bản tin cần xoá");
                        string iName = Console.ReadLine();
                        foreach (New News in New.listBanTins)
                            New.listBanTins.Remove(News);
                        break;
                    case "0":
                        Console.WriteLine("Tạm biệt!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Chức năng không hợp lệ. Hãy chọn lại.");
                        break;
                }

                Console.WriteLine(); // In một dòng trắng để tạo định dạng
            }
        }
        public static void setTimeforNew()
        {
            // Nhập tên kênh
            Console.WriteLine("Nhập tên kênh:");
            string nameofChannel = Console.ReadLine();

            // Nhập tên bản tin
            Console.WriteLine("Nhập tên bản tin:");
            string nameofnew = Console.ReadLine();

            // Nhập thời gian
            Console.WriteLine("Nhập khoảng thời gian (VD: 'sáng', 'chiều', 'tối'):");
            string period = Console.ReadLine();

            // Nhập ngày và tháng
            Console.WriteLine("Nhập ngày:");
            int day;
            while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31)
            {
                Console.WriteLine("Ngày không hợp lệ! Nhập lại:");
            }

            Console.WriteLine("Nhập tháng:");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
            {
                Console.WriteLine("Tháng không hợp lệ! Nhập lại:");
            }

            // Gọi phương thức setTimeAndBanTinForChannel với dữ liệu đã nhập
            setTimeAndBanTinForChannel(nameofChannel, nameofnew, period, day, month);
        }

        public static void nhapBanTin()
        {
            bool continueInput = true;

            while (continueInput)
            {
                Console.WriteLine("Tên bản tin :");
                string name = Console.ReadLine();
                Console.WriteLine("Thời lượng bản tin :");
                double time = double.Parse(Console.ReadLine());
                Console.WriteLine("Nội dung bản tin :");
                string noiDung = Console.ReadLine();
                BanTin bantinNew = new BanTin(name, time, noiDung);

                Category belongstoCategory = null;
                bool validCategory = false;
                foreach (Category iTheLoai in Category.getCategories())
                {
                    Console.WriteLine(iTheLoai.name);
                }
                while (!validCategory)
                {
                    Console.WriteLine("Thể loại của bản tin :");                   
                    string categoryName = Console.ReadLine();
                    belongstoCategory = GetCategoryByName(categoryName);
                    if (belongstoCategory == null)
                    {
                        Console.WriteLine("Thể loại không tồn tại. Vui lòng chọn các lựa chọn sau ");
                        Console.WriteLine("1.Tạo thể loại mới ");
                        Console.WriteLine("2.Nhập lại");
                        int choice1 = int.Parse(Console.ReadLine());
                        switch (choice1)
                        {
                            case 1:
                                Console.WriteLine("Nhập tên thể loại muốn tạo :");
                                string nameCategory = Console.ReadLine();
                                Category addCategory = new Category(nameCategory);
                                Console.WriteLine("Đã tạo thành công " + categoryName);
                                bantinNew.setCategoryName(categoryName);
                                break;
                            case 2:
                                break;
                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                                break;
                        }
                    }
                    else
                    {
                        validCategory = true;
                    }
                }

                Author belongstoAuthor = null;
                bool validAuthor = false;
                foreach (Author iTacGia in Author.getAuthors())
                {
                    Console.WriteLine(iTacGia.name);
                }
                while (!validAuthor)
                {
                    Console.WriteLine("Tác giả của bản tin :");
                    string authorName = Console.ReadLine();
                    belongstoAuthor = getAuthorByName(authorName);

                    if (belongstoAuthor == null)
                    {
                        Console.WriteLine("Tác giả không tồn tại. Vui lòng nhập lại tên tác giả.");
                        Console.WriteLine("1.Tạo tác giả mới");
                        Console.WriteLine("2.Nhập lại ");
                        int choice1 = int.Parse(Console.ReadLine());
                        switch (choice1)
                        {
                            case 1:
                                Console.WriteLine("Nhập thông tin để tạo mới tác giả :");
                                Console.WriteLine("Nhập tên công ty :");
                                string inputCompany = Console.ReadLine();
                                Console.WriteLine("Nhập email :");
                                string inputEmail = Console.ReadLine();
                                Author addAuthor = new Author(authorName, inputCompany, inputEmail);
                                Console.WriteLine("Đã tạo thành công " + authorName);
                                bantinNew.setAuthorName(authorName);
                                break;
                            case 2:
                                break;
                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                                break;
                        }
                    }
                    else
                    {
                        validAuthor = true;
                    }
                }

                Console.WriteLine("1. Nhập tiếp");
                Console.WriteLine("2. Thoát");
                Console.WriteLine("Lựa chọn của bạn: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        continueInput = true;
                        break;
                    case 2:
                        continueInput = false;
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le, lam on nhap lai");
                        break;
                }

            }
        }
        public static void suaBanTin()
        {
            foreach (New iNew in New.listBanTins)
            {
                Console.WriteLine(iNew.getName());
            }
            Console.WriteLine("Tên bản tin: ");
            string thisNew = Console.ReadLine();
            Console.WriteLine("Chọn thông tin muốn sửa: ");
            Console.WriteLine("1. Tên ");
            Console.WriteLine("2. Nội dung ");
            Console.WriteLine("3. Nhân sự ");
            Console.WriteLine("0. Thoát ");
            string choice2 = Console.ReadLine();
            switch (choice2)
            {
                case "1":
                    Console.WriteLine("Nhập tên mới cho Bản Tin: ");
                    try
                    {
                        string newName = Console.ReadLine();
                        foreach (New inNew in New.listBanTins)
                        {
                            if (inNew.getName() == thisNew)
                            {
                                inNew.setName(newName);
                                foreach (TimeSet thoigian in TimeSet.listAllTimeSet)
                                {
                                    if (thoigian.NameBanTin == thisNew)
                                        thoigian.setBanTinOfTimeSet(newName);
                                }
                            }
                            inNew.print();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                    break;


                case "2":
                    Console.WriteLine("Nhập nội dung mới cho Bản Tin: ");
                    try
                    {
                        string newContent = Console.ReadLine();
                        foreach (New inNew in New.listBanTins)
                        {
                            if (inNew.getName() == thisNew)
                            {
                                inNew.setName(newContent);
                                inNew.print();
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                    break;

                case "3":
                    Console.WriteLine("Nhập thời gian chiếu mới: ");
                    try
                    {
                        double newTime = double.Parse(Console.ReadLine());
                        foreach (New inNew in New.listBanTins)
                        {
                            if (inNew.getName() == thisNew)
                            {
                                inNew.setTime(newTime);
                                foreach (TimeSet thoigian in TimeSet.listAllTimeSet)
                                {
                                    if (thoigian.NameBanTin == thisNew)
                                        thoigian.setTime(newTime);
                                    inNew.print();
                                }
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                    break;

                case "0":
                    Console.WriteLine("Thoát");
                    break;

                default:
                    Console.WriteLine("Chức năng không hợp lệ. Hãy chọn lại.");
                    break;
            }

        }

        //đổi vị trí 2 bản tin trong 1 kênh
        // Phương thức hỗ trợ
        public static void SwapBanTin()
        {
            Console.WriteLine("Ngày: ");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Tháng: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập tên của kênh: ");
            string nameChannel = Console.ReadLine();
            Console.WriteLine("Chiếu vào buổi : ");
            string period = Console.ReadLine();

            Console.WriteLine("Bản tin ngày " + day + "/" + month + " gồm: ");
            CalendarDay calendarDay = Calendar.getCalendarDay(day, month);
            if (calendarDay == null)
            {
                Console.WriteLine("Không tìm thấy thông tin cho ngày này.");
                return;
            }

            List<Channel> channels = calendarDay.getListChannels();
            Channel targetChannel = null;
            foreach (Channel channel in channels)
            {
                if (channel.getName() == nameChannel)
                {
                    targetChannel = channel;
                    break;
                }
            }
            if (targetChannel == null)
            {
                Console.WriteLine("Không tìm thấy kênh có tên này.");
                return;
            }

            foreach (New newsItem in targetChannel.getListPeriod(period))
            {
                Console.WriteLine(newsItem.getName());
                foreach (var timeSet in newsItem.getListTime())
                {
                    if (timeSet.NameBanTin == newsItem.getName() && timeSet.NameChannel == targetChannel.getName())
                    {
                        Console.WriteLine("Chiếu lúc : " + timeSet.getTimeStart().ToString("HH:mm:ss"));
                    }
                }
            }

            Console.WriteLine("Nhập tên bản tin muốn đổi vị trí: ");
            Console.WriteLine("Bản Tin 1: ");
            string nameNew1 = Console.ReadLine();
            Console.WriteLine("Bản Tin 2: ");
            string nameNew2 = Console.ReadLine();

            List<New> newsList = targetChannel.getListPeriod(period);
            int index1 = -1;
            int index2 = -1;

            for (int i = 0; i < newsList.Count; i++)
            {
                if (newsList[i].getName() == nameNew1)
                {
                    index1 = i;
                }
                if (newsList[i].getName() == nameNew2)
                {
                    index2 = i;
                }
            }

            if (index1 != -1 && index2 != -1)
            {
                New tempNews = newsList[index1];
                New temp = newsList[index1];
                newsList[index1] = newsList[index2];
                newsList[index2] = temp;

                DateTime iTimeStart;

                for (int currentIndex = 0; currentIndex < targetChannel.getListPeriod(period).Count; currentIndex++)
                {
                    New newsItem = targetChannel.getListPeriod(period)[currentIndex];
                    New previousNewsItem = currentIndex > 0 ? targetChannel.getListPeriod(period)[currentIndex - 1] : null;
                    string newsItemName = newsItem.getName();
                    string previousNewsItemName = previousNewsItem != null ? previousNewsItem.getName() : null;

                    if (period == "sang")
                    {
                        iTimeStart = new DateTime(2024, month, day, 8, 00, 00);
                    }
                    else
                    {
                        iTimeStart = new DateTime(2024, month, day, 16, 00, 00);
                    }

                    double jtime = 0;

                    foreach (TimeSet sTime in TimeSet.listAllTimeSet)
                    {
                        if (previousNewsItemName == sTime.NameBanTin && nameChannel == sTime.NameChannel && day == sTime.getDay() && month == sTime.getMonth())
                        {
                            iTimeStart = sTime.getTimeStart();
                            jtime = sTime.getTime();
                        }
                    }

                    foreach (TimeSet sTime in TimeSet.listAllTimeSet)
                    {
                        if (newsItemName == sTime.NameBanTin && nameChannel == sTime.NameChannel && day == sTime.getDay() && month == sTime.getMonth())
                            sTime.setTimeStart(iTimeStart.AddSeconds(jtime));
                    }
                }
                Console.WriteLine("Đã đổi vị trí và timeStart của hai bản tin trong danh sách.");
            }

            else
            {
                Console.WriteLine("Không tìm thấy bản tin cần đổi vị trí.");
            }
            foreach (New newsItem in targetChannel.getListPeriod(period))
            {
                Console.WriteLine(newsItem.getName());
                foreach (TimeSet timeSet in newsItem.getListTime())
                {
                    if (timeSet.NameBanTin == newsItem.getName() && timeSet.NameChannel == targetChannel.getName())
                    {
                        Console.WriteLine("Chiếu lúc : " + timeSet.getTimeStart().ToString("HH:mm:ss"));
                    }
                }
            }
        }
        public static void SerializeObjectToJsonFile<T>(T obj, string filePath)
        {
            // Serialize đối tượng thành chuỗi JSON
            string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
            });

            try
            {
                // Ghi chuỗi JSON vào tệp văn bản
                File.WriteAllText(filePath, json, System.Text.Encoding.UTF8);
                Console.WriteLine($"Dữ liệu JSON đã được ghi vào file {filePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Lỗi ghi: " + ex.Message);
            }
        }

        public static T DeserializeJsonToObject<T>(string filePath)
        {
            try
            {
                // Đọc dữ liệu từ tệp JSON
                string jsonData = File.ReadAllText(filePath);

                // Deserialize dữ liệu từ tệp thành đối tượng có kiểu dữ liệu T
                T deserializedObject = JsonSerializer.Deserialize<T>(jsonData);

                if (deserializedObject != null)
                {
                    // Hiển thị thông tin của đối tượng sau khi deserialize
                    Console.WriteLine($"Đối tượng đã được deserialize từ tệp {filePath}:");
                    Console.WriteLine(deserializedObject);

                    // Trả về đối tượng đã deserialize
                    return deserializedObject;
                }
                else
                {
                    Console.WriteLine("Dữ liệu deserialized là null.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc dữ liệu từ tệp {filePath}: {ex.Message}");
            }

            // Trả về một giá trị mặc định nếu có lỗi xảy ra hoặc không deserialize được
            return default(T);
        }

        public static Author getAuthorByName(string authorName)
        {
            foreach (Author author in Author.getAuthors())
            {
                if (author.name == authorName)
                {
                    return author;
                }
            }

            return null; // Trả về null nếu không tìm thấy đối tượng Category có tên tương ứng
        }
        public static Category GetCategoryByName(string categoryName)
        {
            foreach (Category category in Category.getCategories())
            {
                if (category.name == categoryName)
                {
                    return category;
                }
            }

            return null; // Trả về null nếu không tìm thấy đối tượng Category có tên tương ứng
        }
    
}
}
