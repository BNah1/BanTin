using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using BanTin;

namespace BanTin
{

    class Program
    {
        static void Main(string[] args)
        {
            createCalendar();
            Test();
        }

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



        // Phương thức chức năng

        public static void Test()
        {
            // tạo bản tin thử
            Category thethao = new Category("the thao");
            Category giaitri = new Category("giai tri");
            Category thoisu = new Category("thoi su");
            Category dubaothoitiet = new Category("dubaothoitiet");
            Author nguyenA = new Author("nguyenA", "Dai VTV", "nguyenA@gmail.com");
            Channel MTV = new Channel("MTV", 5);

            BanTin banTin1 = new BanTin("Ban tin 1", 240, "aaaaaaaaaaaaa");
            QuangCao quangcao1 = new QuangCao("quang cao 1", 10, "1q3123123");
            BanTin banTin2 = new BanTin("Ban tin 2", 140, "bbbbbbbbbbbbb");
            BanTin banTin3 = new BanTin("Ban tin 3", 140, "ccccccccccc");

            thethao.setCategory("Ban tin 2");
            Console.WriteLine("       ");
            banTin2.setTime("sang", "MTV", 10, 3);
            banTin3.setTime("sang", "MTV", 10, 3);
            banTin1.setTime("sang", "MTV", 10, 3);
            banTin1.print();
            banTin2.print();
            banTin3.print();

        }
        public static void QuanLiBanTin()
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Thêm bản tin");
                Console.WriteLine("2. Đặt thể loại");
                Console.WriteLine("3. Đặt tác giả");
                Console.WriteLine("4. Chọn kênh");
                Console.WriteLine("5. Đặt thời gian chiếu");
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
                        Console.WriteLine("Bạn đã chọn Đặt thể loại");
                        // Gọi phương thức đặt thể loại ở đây
                        break;

                    case "3":
                        Console.WriteLine("Bạn đã chọn Đặt tác giả");
                        // Gọi phương thức đặt tác giả ở đây
                        break;

                    case "4":
                        Console.WriteLine("Bạn đã chọn Chọn kênh");
                        // Gọi phương thức chọn kênh ở đây
                        break;

                    case "5":
                        Console.WriteLine("Bạn đã chọn Đặt thời gian chiếu");
                        // Gọi phương thức đặt thời gian chiếu ở đây
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
        public static void nhapDuLieu()
        {
            // tạo bản tin thử
            Category thethao = new Category("thethao");
            Category giaitri = new Category("giaitri");
            Category thoisu = new Category("thoisu");
            Category dubaothoitiet = new Category("dubaothoitiet");
            Author nguyenA = new Author("nguyenA", "Dai VTV", "nguyenA@gmail.com");
            Channel MTV = new Channel("MTV", 5);
            Channel vtv1 = new Channel("vtv1", 5);
            Channel vtv2 = new Channel("vtv2", 5);
            Channel vtv3 = new Channel("vtv3", 5);


            BanTin banTin1 = new BanTin("Bản tin 1", 10.5, "Nội dung bản tin 1");

            BanTin banTin2 = new BanTin("Bản tin 2", 10.5, "Nội dung bản tin 1");

            BanTin banTin3 = new BanTin("Bản tin 3", 10.5, "Nội dung bản tin 1");

            BanTin banTin4 = new BanTin("Bản tin 4", 10.5, "Nội dung bản tin 1");

            BanTin banTin5 = new BanTin("Bản tin 5", 10.5, "Nội dung bản tin 1");


            Category.printAllCategory();
            MTV.channelAddBanTin("Bản tin 1", "sang");
            MTV.channelAddBanTin("Bản tin 2", "sang");
            MTV.printAll();
            giaitri.printAllBanTin();

            Console.WriteLine("Nhap thoi diem ma ban muon them ban tin vao :");
            Console.WriteLine("1.Sang");
            Console.WriteLine("2.Toi");
            string inputPeriod = Console.ReadLine();

            Console.WriteLine(banTin1.ToString());



            //string timeStart = "3:29:59";
            //DateTime startTime = DateTime.ParseExact(timeStart, "H:mm:ss", null);
            //DateTime startTime1 = DateTime.ParseExact(timeStart, "H:mm:ss", null);

            //double time = 120; // Giây
            //TimeSpan duration = TimeSpan.FromSeconds(time);

            //DateTime endTime = startTime.Add(duration);

            //string timeEnd = endTime.ToString("H:mm:ss");
            //Console.WriteLine("Thời gian kết thúc: " + timeEnd);
            //Console.WriteLine("Thời gian kết thúc: " + time);

        }



        // Phương thức hỗ trợ

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

        public void Nhap()
        {
            //    bool exit = false;
            //    while (!exit)
            //    {
            //        Console.WriteLine("---- Quan ly ban tin truyen hinh ----");
            //        Console.WriteLine("---- 1. Quản lý bản tin ");
            //        Console.WriteLine("---- 2. Quản lý tác giả ");
            //        Console.WriteLine("---- 3. Quản lý kênh ");
            //        Console.WriteLine("---- 4. Quản lý quảng cáo ");
            //        Console.WriteLine("---- 5. Quản lý thời gian trình chiếu ");
            //        Console.WriteLine("---- 6. Quản lý thể loại ");
            //        Console.WriteLine("---- 7. Thoat ");
            //        Console.WriteLine("--------------------------------------");


            //        Console.WriteLine("Nhập lựa chọn của bạn:");
            //        string choice = Console.ReadLine();
            //        switch (choice)
            //        {
            //            case "1":
            //                Console.WriteLine("--- Quản lý bản tin --- ");
            //                Console.WriteLine("---- 1. Tạo bản tin mới ");
            //                Console.WriteLine("---- 2. Chỉnh sửa bản tin ");
            //                Console.WriteLine("---- 3. Đổi thể loại ");
            //                Console.WriteLine("---- 4. Đổi kênh ");
            //                Console.WriteLine("---- 5. Quay lại ");


            //                string subChoice1 = Console.ReadLine();
            //                switch (subChoice1)
            //                {
            //                    case "1":
            //                        Console.WriteLine("Tạo bản tin mới");
            //                        // Thực hiện hành động tạo bản tin mới
            //                        break;
            //                    case "2":
            //                        Console.WriteLine("Chỉnh sửa bản tin");
            //                        // Thực hiện hành động chỉnh sửa bản tin
            //                        break;
            //                    case "3":
            //                        Console.WriteLine("Đổi thể loại");
            //                        // Thực hiện hành động đổi thể loại
            //                        break;
            //                    case "4":
            //                        Console.WriteLine("Đổi kênh");
            //                        // Thực hiện hành động đổi kênh
            //                        break;
            //                    case "5":
            //                        Console.WriteLine("Quay lại menu chính");
            //                        // Thoát khỏi switch và quay lại menu chính
            //                        break;
            //                    default:
            //                        Console.WriteLine("Lựa chọn không hợp lệ");
            //                        break;
            //                }
            //                break;
            //            case "2":
            //                // Xử lý lựa chọn 2
            //                break;
            //            case "3":
            //                // Xử lý lựa chọn 3
            //                break;
            //            case "4":
            //                // Xử lý lựa chọn 4
            //                break;
            //            case "5":
            //                // Xử lý lựa chọn 5
            //                break;
            //            case "6":
            //                // Xử lý lựa chọn 6
            //                break;
            //            case "7":
            //                exit = true; // Đặt biến exit thành true để thoát khỏi vòng lặp
            //                Console.WriteLine("Thoát chương trình");
            //                break;
            //            default:
            //                Console.WriteLine("Lựa chọn không hợp lệ");
            //                break;
            //        }

            //        Console.WriteLine();
            //    }
            //            case "2":
            //        Console.WriteLine("Bạn đã chọn lựa chọn 2");
            //        // Thực hiện hành động tương ứng với lựa chọn 2
            //        break;
            //    case "3":
            //        Console.WriteLine("Thoát chương trình");
            //        exit = true;
            //        break;
            //    default:
            //        Console.WriteLine("Lựa chọn không hợp lệ");
            //        break;
            //    }

            //    Console.WriteLine();
            //}
        }

    }


}
