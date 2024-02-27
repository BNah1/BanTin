using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BanTin;

namespace BanTin
{

    class Program
    {
        static void Main(string[] args)
        {   
            createCalendar();
        }

        public static void createCalendar()
        {   
            // tao lich cac ngay trong nam 2024
            List<Calendar> calendarOf2024 = new List<Calendar>();
            for (int i = 0; i < 12; i++)
            {
                Calendar calendar = new Calendar(2024, i + 1);
                calendarOf2024.Add(calendar);

                List<DateTime> Days = calendar.GetDays();
                foreach (DateTime day in Days)
                {
                    Console.WriteLine(day.ToString("dd/MM/yyyy"));
                }
            }
        }

        public static void Test()
        {
            // tạo bản tin thử
            Category thethao = new Category("the thao");
            Category giaitri = new Category("giai tri");
            Category thoisu = new Category("thoi su");
            Category dubaothoitiet = new Category("dubaothoitiet");
            Author nguyenA = new Author("nguyenA", "Dai VTV", "nguyenA@gmail.com");
            Channel MTV = new Channel("MTV", 5);

            BanTin banTin1 = new BanTin("Ban tin 1", 10.5, "aaaaaaaaaaaaa");

            BanTin banTin2 = new BanTin("Ban tin 2", 11.5, "bbbbbbbbbbbbb");

            thethao.setCategory("Ban tin 2");
            giaitri.printAllBanTin();
            thethao.printAllBanTin();
            MTV.channelAddBanTin("Ban tin 1", "sang");
            MTV.printAll();
            Console.WriteLine(banTin1.getListChanels());
            //thethao.printAllBanTin();
            //banTin2.getCategoryName();
            BanTin.printAll();

        }

        public static void createBanTin()
        {
            Console.WriteLine("Nhap ten cua ban tin :");
            string inputName = Console.ReadLine();
            Console.WriteLine("Nhap thoi luong cua ban tin :");
            double inputTime = Double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap noi dung cua ban tin :");
            string inputInfo = Console.ReadLine();
            BanTin bantin = new BanTin(inputName, inputTime, inputInfo);

        }




        public static void nhapBanTin()
        {
            bool continueInput = true;

            while (continueInput)
            {
                Console.WriteLine("Ten ban tin :");
                string name = Console.ReadLine();
                Console.WriteLine("Thoi luong ban tin :");
                double time = double.Parse(Console.ReadLine());
                Console.WriteLine("Noi dung ban tin :");
                string noiDung = Console.ReadLine();
                BanTin bantinNew = new BanTin(name, time, noiDung);

                Category belongstoCategory = null;
                bool validCategory = false;
                while (!validCategory)
                {
                    Console.WriteLine("The loai cua ban tin :");
                    string categoryName = Console.ReadLine();
                    belongstoCategory = GetCategoryByName(categoryName);

                    if (belongstoCategory == null)
                    {
                        Console.WriteLine("Thể loại không tồn tại. Vui long chon cac lua chon sau ");
                        Console.WriteLine("1.Tao the loai moi");
                        Console.WriteLine("2.Nhap lai");
                        int choice1 = int.Parse(Console.ReadLine());
                        switch (choice1)
                        {
                            case 1:
                                Category addCategory = new Category(categoryName);
                                Console.WriteLine("Da tao thanh cong " + categoryName);
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
                    Console.WriteLine("Tac gia cua ban tin :");
                    string authorName = Console.ReadLine();
                    belongstoAuthor = getAuthorByName(authorName);

                    if (belongstoAuthor == null)
                    {
                        Console.WriteLine("Tác giả không tồn tại. Vui lòng nhập lại tên tác giả.");
                        Console.WriteLine("1.Tao tac gia moi");
                        Console.WriteLine("2.Nhap lai");
                        int choice1 = int.Parse(Console.ReadLine());
                        switch (choice1)
                        {
                            case 1:
                                Console.WriteLine("Nhap ten cong ty :");
                                string inputCompany = Console.ReadLine();
                                Console.WriteLine("Nhap email :");
                                string inputEmail = Console.ReadLine();
                                Author addAuthor = new Author(authorName, inputCompany, inputEmail);
                                Console.WriteLine("Da tao thanh cong " + authorName);
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
            switch (inputPeriod)
            {
                case "1":
                    banTin1.setTimePeriod("sang");
                    break;

                case "2":
                    banTin1.setTimePeriod("toi");
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ nhập lại");
                    break;
            }
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
