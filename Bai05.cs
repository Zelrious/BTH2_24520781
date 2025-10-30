using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Bai05
    {
        //Lớp cơ sở
        abstract class BatDongSan
        {
            public string DiaDiem { get; set; }
            public double GiaBan { get; set; }
            public double DienTich { get; set; }

            public virtual void Nhap()
            {
                Console.Write("Nhap dia diem: ");
                DiaDiem = Console.ReadLine() ?? "";

                // Yêu cầu giá bán > 0
                GiaBan = ReadDouble("Nhap gia ban (Trieu VND, >0): ", 1);

                // Yêu cầu diện tích > 0
                DienTich = ReadDouble("Nhap dien tich (m2, >0): ", 1);
            }

            public virtual void Xuat()
            {
                Console.WriteLine($"Dia diem: {DiaDiem} | Gia: {GiaBan:N0} VND | Dien tich: {DienTich} m2");
            }

            public abstract string Loai();

            //Hàm đọc số thực
            protected double ReadDouble(string prompt, double min)
            {
                double value;
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine() ?? "";

                    if (double.TryParse(input, out value) && value >= min)
                        return value;

                    Console.Write("Nhap sai kieu du lieu, hay nhap lai\n");
                }
            }

            //Hàm đọc số nguyên
            protected int ReadInt32(string prompt, int min, int max = int.MaxValue)
            {
                int value;
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine() ?? "";

                    if (Int32.TryParse(input, out value) && value >= min && value <= max)
                        return value;

                    Console.Write("Nhap sai kieu du lieu, hay nhap lai\n");
                }
            }
        }

        //================ KHU ĐẤT =================
        class KhuDat : BatDongSan
        {
            public override string Loai() => "KhuDat";

            public override void Nhap()
            {
                Console.WriteLine("\n=== Nhap thong tin Khu Dat ===");
                base.Nhap();
            }

            public override void Xuat()
            {
                Console.Write("[Khu Dat] ");
                base.Xuat();
            }
        }

        //================ NHÀ PHỐ =================
        class NhaPho : BatDongSan
        {
            public int NamXayDung { get; set; }
            public int SoTang { get; set; }

            public override string Loai() => "NhaPho";

            public override void Nhap()
            {
                Console.WriteLine("\n=== Nhap thong tin Nha Pho ===");
                base.Nhap();

                int namHienTai = DateTime.Now.Year;
                NamXayDung = ReadInt32($"Nhap nam xay dung: ", 1, namHienTai);
                SoTang = ReadInt32("Nhap so tang (>0): ", 1);
            }

            public override void Xuat()
            {
                Console.Write("[Nha Pho] ");
                base.Xuat();
                Console.WriteLine($" | Nam XD: {NamXayDung} | So tang: {SoTang}");
            }
        }


        //================ CHUNG CƯ =================
        class ChungCu : BatDongSan
        {
            public int Tang { get; set; }

            public override string Loai() => "ChungCu";

            public override void Nhap()
            {
                Console.WriteLine("\n=== Nhap thong tin Chung Cu ===");
                base.Nhap();
                Tang = ReadInt32("Nhap tang: ", 1);
            }

            public override void Xuat()
            {
                Console.Write("[Chung Cu] ");
                base.Xuat();
                Console.WriteLine($" | Tang: {Tang}");
            }
        }

        //================ QUẢN LÝ =================
        class QuanLyBDS
        {
            private List<BatDongSan> ds = new List<BatDongSan>();

            public void NhapDS()
            {
                int n = ReadInt32("Nhap so luong bat dong san: ", 1);
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\n--- Nhap bat dong san thu {i + 1} ---");
                    Console.WriteLine("1. Khu Dat\n2. Nha Pho\n3. Chung Cu");
                    int loai = ReadInt32("Chon loai BDS (1-3): ", 1, 3);

                    BatDongSan bds;
                    if (loai == 1) bds = new KhuDat();
                    else if (loai == 2) bds = new NhaPho();
                    else bds = new ChungCu();

                    bds.Nhap();
                    ds.Add(bds);
                }
            }

            public void XuatDS()
            {
                if (ds.Count == 0)
                {
                    Console.WriteLine("\nDanh sach rong!");
                    return;
                }

                Console.WriteLine("\n=== Danh sach bat dong san ===");
                foreach (var bds in ds)
                    bds.Xuat();
            }

            public void TongGiaTheoLoai()
            {
                double tongDat = 0, tongNha = 0, tongCC = 0;
                foreach (var bds in ds)
                {
                    switch (bds.Loai())
                    {
                        case "KhuDat": tongDat += bds.GiaBan; break;
                        case "NhaPho": tongNha += bds.GiaBan; break;
                        case "ChungCu": tongCC += bds.GiaBan; break;
                    }
                }

                Console.WriteLine("Tong gia ban tung loai:");
                Console.WriteLine($"\nTong gia ban Khu Dat: {tongDat:N0}");
                Console.WriteLine($"Tong gia ban Nha Pho: {tongNha:N0}");
                Console.WriteLine($"Tong gia ban Chung Cu: {tongCC:N0}");
            }

            public void XuatTheoDieuKien()
            {
                if (ds.Count == 0)
                {
                    Console.WriteLine("\nDanh sach rong!");
                    return;
                }

                Console.WriteLine("\n=== Danh sach theo dieu kien ===");
                bool found = false;

                foreach (var bds in ds)
                {
                    if (bds is KhuDat kd && kd.DienTich > 100)
                    {
                        kd.Xuat();
                        found = true;
                    }
                    else if (bds is NhaPho np && np.DienTich > 60 && np.NamXayDung >= 2019)
                    {
                        np.Xuat();
                        found = true;
                    }
                }

                if (!found)
                    Console.WriteLine("Khong co bat dong san nao thoa dieu kien!");
            }

            public void TimKiem()
            {
                if (ds.Count == 0)
                {
                    Console.WriteLine("\nDanh sach rong!");
                    return;
                }

                Console.WriteLine("\n=== Tim kiem bat dong san (khong bao gom Khu Dat) ===");
                Console.Write("Nhap dia diem can tim: ");
                string key = Console.ReadLine()?.Trim().ToLower() ?? "";

                double gia = ReadDouble("Nhap gia toi da (>0): ", 1);
                double dientich = ReadDouble("Nhap dien tich toi thieu (>0): ", 1);

                var ketqua = ds.Where(bds =>
                    !(bds is KhuDat) && 
                    bds.DiaDiem.ToLower().Contains(key) &&
                    bds.GiaBan <= gia &&
                    bds.DienTich >= dientich
                );

                Console.WriteLine("\nKet qua tim kiem:");
                foreach (var bds in ketqua)
                    bds.Xuat();

                if (!ketqua.Any())
                    Console.WriteLine("Khong co bat dong san phu hop!");
            }


            private int ReadInt32(string prompt, int min, int max = int.MaxValue)
            {
                int value;
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine() ?? "";

                    if (Int32.TryParse(input, out value) && value >= min && value <= max)
                        return value;

                    Console.Write("Nhap sai kieu du lieu, hay nhap lai\n");
                }
            }

            private double ReadDouble(string prompt, double min)
            {
                double value;
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine() ?? "";

                    if (double.TryParse(input, out value) && value >= min)
                        return value;

                    Console.Write("Nhap sai kieu du lieu, hay nhap lai\n");
                }
            }
        }

        public static void Run_bai5()
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLyBDS ql = new QuanLyBDS();
            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("\n===== MENU QUAN LY BDS DAI PHU =====");
                Console.WriteLine("1. Nhap danh sach bat dong san");
                Console.WriteLine("2. Xuat danh sach bat dong san");
                Console.WriteLine("3. Xuat tong gia ban tung loai");
                Console.WriteLine("4. Xuat danh sach theo dieu kien");
                Console.WriteLine("5. Tim kiem bat dong san");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon (0-5): ");

                while (true)
                {
                    string input = Console.ReadLine() ?? "";
                    if (!Int32.TryParse(input, out choice))
                    {
                        Console.Write("Nhap sai kieu du lieu, hay nhap lai: ");
                        continue;
                    }
                    if (choice < 0 || choice > 5)
                    {
                        Console.Write("Lua chon khong dung, hay nhap lai: ");
                        continue;
                    }
                    break;
                }

                switch (choice)
                {
                    case 1:
                        ql.NhapDS();
                        break;
                    case 2:
                        ql.XuatDS();
                        break;
                    case 3:
                        ql.TongGiaTheoLoai();
                        break;
                    case 4:
                        ql.XuatTheoDieuKien();
                        break;
                    case 5:
                        ql.TimKiem();
                        break;
                    case 0:
                        Console.WriteLine("\n==== THOAT CHUONG TRINH 5 ====\n");
                        break;
                }
            }
        }
    }
}