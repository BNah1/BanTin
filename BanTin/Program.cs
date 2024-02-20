using System;
using System.Collections.Generic;
using BanTin;

namespace BanTin
{

    class Program
    {
            static void Main(string[] args)
            {

            // tạo bản tin thử
            Category thethao = new Category();
                Category giaitri = new Category();
                Category thoisu = new Category();
                Category dubaothoitiet = new Category();
                Author nguyenA = new Author();
                Channel MTV = new Channel("MTV", 5);


                BanTin banTin1 = new BanTin("Bản tin 1", 10.5, "Nội dung bản tin 1", "08:00", "08:10", thethao, nguyenA);

                BanTin banTin2 = new BanTin("Bản tin 2", 10.5, "Nội dung bản tin 1", "08:00", "08:10", dubaothoitiet, nguyenA);

                BanTin banTin3 = new BanTin("Bản tin 3", 10.5, "Nội dung bản tin 1", "08:00", "08:10", thoisu, nguyenA);

                BanTin banTin4 = new BanTin("Bản tin 4", 10.5, "Nội dung bản tin 1", "08:00", "08:10", thethao, nguyenA);

                BanTin banTin5 = new BanTin("Bản tin 5", 10.5, "Nội dung bản tin 1", "08:00", "08:10", giaitri, nguyenA);

                BanTin.printAll();

                giaitri.removeCategory(banTin5);
                MTV.channelAddBanTin(banTin5);
                MTV.channelAddBanTin(banTin4);
                MTV.printAll();
                



                string timeStart = "3:29:59";
                DateTime startTime = DateTime.ParseExact(timeStart, "H:mm:ss", null);
                DateTime startTime1 = DateTime.ParseExact(timeStart, "H:mm:ss", null);

                int time = 120; // Giây
                TimeSpan duration = TimeSpan.FromSeconds(time);

                DateTime endTime = startTime.Add(duration);

                string timeEnd = endTime.ToString("H:mm:ss");
                Console.WriteLine("Thời gian kết thúc: " + timeEnd);
                Console.WriteLine("Thời gian kết thúc: " + time);

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

