using System;
using System.IO;
using System.Text.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using BanTin;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.Design;

namespace BanTin
{

    class Program
    {
        private static readonly string filePath = "C:\\Users\\PC\\source\\repos\\BanTin\\BanTin\\data.json";
        static BanTinList banTinList1 = new BanTinList();
        static BanTinList banTinList2 = new BanTinList();
        static void Main(string[] args)
        {
            PhuongThuc.createCalendar();
            KhoiTao();
            DangNhap();
            Menu();
        }

        public static void KhoiTao()
        {
            // Tao kenh VTV1 o tat ca cac ngay
            PhuongThuc.addChannel("VTV1", 5);
            PhuongThuc.addChannel("VTV2", 5);
            PhuongThuc.addChannel("VTV3", 5);

            // Tạo các bản tin
            BanTin banTin1 = new BanTin("BanTin1", 180, "Nội dung bản tin 1");
            BanTin banTin2 = new BanTin("BanTin2", 150, "Nội dung bản tin 2");
            BanTin banTin3 = new BanTin("BanTin3", 120, "Nội dung bản tin 3");
            BanTin banTin4 = new BanTin("BanTin4", 90, "Nội dung bản tin 4");
            BanTin banTin5 = new BanTin("BanTin5", 90, "Nội dung bản tin 4");
            banTinList1.Add(banTin1);
            banTinList1.Add(banTin2);
            banTinList1.Add(banTin3);
            banTinList1.Add(banTin4);
            banTinList1.Add(banTin5);

            QuangCao quangcao1 = new QuangCao("QuangCao1", 30, "bbbb");
            QuangCao quangcao2 = new QuangCao("QuangCao2", 30, "bbbb");
            LiveStream live1 = new LiveStream("Live1", 50, "bbbb");
            LiveStream live2 = new LiveStream("Live1", 50, "bbbb");

            // tạo thể loại + 
            Category thethao = new Category("The Thao");
            Category giaitri = new Category("Giai Tri");
            Category thoisu = new Category("Thoi Su");
            Author nguyenA = new Author("Nguyen A", "Dai VTV", "nguyenA@gmail.com");
            Author nguyenB = new Author("Nguyen B", "Dai VTV", "nguyenA@gmail.com");
            Author nguyenC = new Author("Nguyen C", "Dai VTV", "nguyenA@gmail.com");
            Anchor LeA = new Anchor("Le A", "Dai VTV", "nguyenA@gmail.com");
            Reporter TranA = new Reporter("Tran A", "Dai VTV", "nguyenA@gmail.com");


            nguyenA.setAuthor("BanTin1");
            nguyenA.setAuthor("BanTin2");
            nguyenA.setAuthor("BanTin3");
            nguyenA.setAuthor("BanTin4");
            nguyenA.setAuthor("BanTin5");
            LeA.addChannelforAnchor("VTV1");
            LeA.addChannelforAnchor("VTV2");
            LeA.addChannelforAnchor("VTV3");


            thethao.setCategory("BanTin1");
            thethao.setCategory("BanTin2");
            giaitri.setCategory("BanTin3");
            giaitri.setCategory("BanTin4");
            thoisu.setCategory("BanTin5");


            //Đặt thời gian cho các bản tin
            Console.WriteLine("--------------");
            PhuongThuc.setTimeAndBanTinForChannel("VTV1", "BanTin1", "sang", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV1", "BanTin2", "sang", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV1", "BanTin3", "sang", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV1", "QuangCao1", "sang", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV2", "Live", "sang", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV2", "BanTin2", "sang", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV2", "BanTin3", "sang", 3, 3);

            PhuongThuc.setTimeAndBanTinForChannel("VTV1", "BanTin1", "toi", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV1", "BanTin2", "toi", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV1", "BanTin3", "toi", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV1", "QuangCao1", "toi", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV2", "Live", "toi", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV2", "BanTin2", "toi", 3, 3);
            PhuongThuc.setTimeAndBanTinForChannel("VTV2", "BanTin3", "toi", 3, 3);



        }

        public static void DangNhap()
        {
            Service service = new Service();
            Console.WriteLine("Mời bạn đăng nhập");
            bool loggedIn = false;
            do
            {
                Console.WriteLine("Nhập tên đăng nhập:");
                string username = Console.ReadLine();

                Console.WriteLine("Nhập mật khẩu:");
                string password = Console.ReadLine(); // Sử dụng phương thức ReadPassword() đã được định nghĩa trước đó

                // Thực hiện kiểm tra tên đăng nhập và mật khẩu ở đây
                // Nếu thông tin đăng nhập đúng, đặt biến loggedIn thành true, ngược lại, hiển thị thông báo lỗi và yêu cầu nhập lại
                if (service.Login(username, password))
                {
                    Menu();
                }
                else
                {
                    Console.WriteLine("Tên đăng nhập hoặc mật khẩu không chính xác. Vui lòng thử lại.");
                }
            } while (!loggedIn);
            Console.WriteLine("Đăng nhập thành công ");
        }

        public static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("---- Quan ly ban tin truyen hinh ----");
                Console.WriteLine("---- 1. Quản lý bản tin ");
                Console.WriteLine("---- 2. Quản lý nhân sự ");
                Console.WriteLine("---- 3. Quản lý kênh ");
                Console.WriteLine("---- 4. Quản lý thể loại ");
                Console.WriteLine("---- 5. Quản lý thời gian trình chiếu ");
                Console.WriteLine("---- 6. Đọc dữ liệu từ file JSON ");
                Console.WriteLine("---- 7. Lưu dữ liệu vừa thao tác vào file JSON ");
                Console.WriteLine("---- 8. Thoát ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine("Nhập lựa chọn của bạn:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PhuongThuc.QuanLiBanTin();
                        break;
                    case "2":
                        PhuongThuc.QuanLiPeople();
                        break;
                    case "3":
                        PhuongThuc.QuanLiKenh();
                        break;
                    case "4":
                        PhuongThuc.QuanLiTheLoai();
                        break;
                    case "5":
                        PhuongThuc.QuanLiSetTime();
                        break;
                    case "6":
                        BanTinList deserializeBanTin = PhuongThuc.DeserializeJsonToObject<BanTinList>(filePath);
                        foreach (BanTin bantin in deserializeBanTin.Bantins)
                        {
                            Console.WriteLine(bantin.ToString());
                        }
                        break;
                    case "7":
                        BanTinList chooseBanTinToJson = banTinList1 == PhuongThuc.banTinListNew ? banTinList1 : PhuongThuc.banTinListNew;
                        PhuongThuc.SerializeObjectToJsonFile(chooseBanTinToJson, filePath);
                        break;
                    case "8":
                        exit = true; // Đặt biến exit thành true để thoát khỏi vòng lặp
                        Console.WriteLine("Thoát chương trình");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }


                Console.WriteLine();
            }
        }

        static void SerializeObjectToJsonFile<T>(T obj, string filePath)
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

        static T DeserializeJsonToObject<T>(string filePath)
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
    }
}
