﻿using System;
using System.Collections.Generic;
using BanTin;

namespace BanTin
{

    class Program
    {
            static void Main(string[] args)
            {

            Category.printAllCategory();
                nhapDuLieu();
                nhapBanTin();

            }


        public static void nhapBanTin()
        {
            bool continueInput = true;

            while (continueInput)
            {
                Console.WriteLine("So luong ban tin muon khai :");
                int count = int.Parse(Console.ReadLine());
                Console.WriteLine("Ten ban tin :");
                string name = Console.ReadLine();
                Console.WriteLine("Thoi luong ban tin :");
                double time = double.Parse(Console.ReadLine());
                Console.WriteLine("Noi dung ban tin :");
                string noiDung = Console.ReadLine();

                //Console.WriteLine("The loai cua ban tin :");
                //string categoryName = Console.ReadLine();
                //Console.WriteLine("Tac gia cua ban tin :");
                //string authorName = Console.ReadLine();
                //Category belongstoCategory = GetCategoryByName(categoryName);
                //if (belongstoCategory == null)
                //{
                //    Console.WriteLine("Thể loại không tồn tại. Vui lòng nhập lại tên thể loại.");
                //    continue;
                //}
                //Author belongstoAuthor = getAuthorByName(authorName);
                //if (belongstoAuthor == null)
                //{
                //    Console.WriteLine("Tác giả không tồn tại. Vui lòng nhập lại tên tác giả.");
                //    continue;
                //}
                Category belongstoCategory = null;
                bool validCategory = false;
                while (!validCategory)
                {
                    Console.WriteLine("The loai cua ban tin :");
                    string categoryName = Console.ReadLine();
                    belongstoCategory = GetCategoryByName(categoryName);

                    if (belongstoCategory == null)
                    {
                        Console.WriteLine("Thể loại không tồn tại. Vui lòng nhập lại tên thể loại.");
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
                    }
                    else
                    {
                        validAuthor = true;
                    }
                }

                BanTin.listBanTins.Add(new BanTin(name, time, noiDung, belongstoCategory, belongstoAuthor));

                //BanTin.listBanTins.Add(new BanTin(name, time, noiDung, belongstoCategory, belongstoAuthor));

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
            foreach (Category category in Category.categories)
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
            foreach (Author author in Author.authors)
            {
                if (author.name == authorName)
                {
                    return author;
                }
            }

            return null; // Trả về null nếu không tìm thấy đối tượng Category có tên tương ứng
        }

        public static void nhapDuLieu() {
            // tạo bản tin thử
            Category thethao = new Category("thethao");
            Category giaitri = new Category("giaitri");
            Category thoisu = new Category("thoisu");
            Category dubaothoitiet = new Category("dubaothoitiet");
            Author nguyenA = new Author();
            Channel vtv1 = new Channel("vtv1", 5);
            Channel vtv2 = new Channel("vtv2", 5);
            Channel vtv3 = new Channel("vtv3", 5);


            BanTin banTin1 = new BanTin("Bản tin 1", 10.5, "Nội dung bản tin 1", thethao, nguyenA);

            BanTin banTin2 = new BanTin("Bản tin 2", 10.5, "Nội dung bản tin 1", dubaothoitiet, nguyenA);

            BanTin banTin3 = new BanTin("Bản tin 3", 10.5, "Nội dung bản tin 1", thoisu, nguyenA);

            BanTin banTin4 = new BanTin("Bản tin 4", 10.5, "Nội dung bản tin 1", thethao, nguyenA);

            BanTin banTin5 = new BanTin("Bản tin 5", 10.5, "Nội dung bản tin 1", giaitri, nguyenA);


            giaitri.removeCategory(banTin5);
            //MTV.channelAddBanTin(banTin5);
            //MTV.channelAddBanTin(banTin4);
            //MTV.printAll();
      
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

