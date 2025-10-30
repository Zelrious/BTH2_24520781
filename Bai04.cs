using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Bai04
    {
        // Cài đặt lớp phân số
        class PhanSo
        {
            public int Tu { get; set; }
            public int Mau { get; set; }

            public PhanSo(int tu = 0, int mau = 1)
            {
                if (mau == 0)
                    throw new ArgumentException("Mau so khong duoc bang 0");
                Tu = tu;
                Mau = mau;
                RutGon();
            }

            private void RutGon()
            {
                int gcd = UCLN(Math.Abs(Tu), Math.Abs(Mau));
                Tu /= gcd;
                Mau /= gcd;
                if (Mau < 0)
                {
                    Tu = -Tu;
                    Mau = -Mau;
                }
            }

            private int UCLN(int a, int b)
            {
                return b == 0 ? a : UCLN(b, a % b);
            }

            public override string ToString()
            {
                if (Tu == 0) return "0";
                if (Tu == Mau) return "1";
                if (Mau == 1) return Tu.ToString();
                return $"{Tu}/{Mau}";
            }


            // Cài đặt các toán tử
            public static PhanSo operator +(PhanSo a, PhanSo b)
                => new PhanSo(a.Tu * b.Mau + b.Tu * a.Mau, a.Mau * b.Mau);

            public static PhanSo operator -(PhanSo a, PhanSo b)
                => new PhanSo(a.Tu * b.Mau - b.Tu * a.Mau, a.Mau * b.Mau);

            public static PhanSo operator *(PhanSo a, PhanSo b)
                => new PhanSo(a.Tu * b.Tu, a.Mau * b.Mau);

            public static PhanSo operator /(PhanSo a, PhanSo b)
            {
                if (b.Tu == 0)
                {
                    Console.WriteLine("Khong the chia cho phan so co tu = 0. Ket qua duoc gan bang 0.");
                    return new PhanSo(0, 1);
                }
                return new PhanSo(a.Tu * b.Mau, a.Mau * b.Tu);
            }

            // Cài đặt toán tử so sánh
            public static bool operator >(PhanSo a, PhanSo b)
                => (double)a.Tu / a.Mau > (double)b.Tu / b.Mau;

            public static bool operator <(PhanSo a, PhanSo b)
                => (double)a.Tu / a.Mau < (double)b.Tu / b.Mau;

            public static bool operator ==(PhanSo a, PhanSo b)
                => a.Tu * b.Mau == b.Tu * a.Mau;

            public static bool operator !=(PhanSo a, PhanSo b)
                => !(a == b);

            public override bool Equals(object obj)
                => obj is PhanSo other && this == other;

            public override int GetHashCode()
                => Tu.GetHashCode() ^ Mau.GetHashCode();
        }

        // Cài đặt lớp quản lý mảng phân số
        class QuanLyPhanSo
        {
            private List<PhanSo> danhSach = new List<PhanSo>();

            // Hàm đọc một số nguyên
            private bool ReadInt(ref int n)
            {
                string input = Console.ReadLine();
                bool check = Int32.TryParse(input, out n);
                return check;
            }

            //Hàm nhập một phân số
            private PhanSo NhapPhanSo()
            {
                int tu = 0, mau = 1;

                Console.Write("Nhap tu so: ");
                while (!ReadInt(ref tu))
                    Console.Write("Tu so phai la so nguyen, hay nhap lai: ");

                Console.Write("Nhap mau so (khac 0): ");
                while (!ReadInt(ref mau) || mau == 0)
                    Console.Write("Mau so phai la so nguyen khac 0, hay nhap lai: ");

                return new PhanSo(tu, mau);
            }

            // Hàm nhập danh sách phân số
            public void NhapDanhSach()
            {
                int n = 0;
                Console.Write("Nhap so luong phan so: ");
                while (!ReadInt(ref n) || n <= 0)
                    Console.Write("So luong phai la so nguyen duong, hay nhap lai: ");

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nNhap phan so thu {i + 1}:");
                    danhSach.Add(NhapPhanSo());
                }
            }

            //Hàm xuất danh sách phân số
            public void XuatDanhSach()
            {
                foreach (var ps in danhSach)
                    Console.Write(ps + "  ");
                Console.WriteLine();
            }

            //Hàm tìm phân số lớn nhất
            public PhanSo TimMax()
            {
                if (danhSach.Count == 0)
                    throw new InvalidOperationException("Danh sach rong");
                PhanSo max = danhSach[0];
                foreach (var ps in danhSach)
                    if (ps > max) max = ps;
                return max;
            }

            //Hàm sắp xếp các phân số
            public void SapXepTangDan()
            {
                danhSach.Sort((a, b) => ((double)a.Tu / a.Mau).CompareTo((double)b.Tu / b.Mau));
            }
        }

        static PhanSo NhapPhanSo(string thongtin)
        {
            int tu = 0, mau = 1;
            Console.WriteLine(thongtin);
            Console.Write("Nhap tu so: ");
            while (!ReadInt(ref tu))
                Console.Write("Tu so phai la so nguyen, hay nhap lai: ");

            Console.Write("Nhap mau so (Khac 0): ");
            while (!ReadInt(ref mau) || mau == 0)
                Console.Write("Mau so phai la so nguyen khac 0, hay nhap lai: ");

            return new PhanSo(tu, mau);
        }

        static bool ReadInt(ref int n)
        {
            string input = Console.ReadLine();
            bool check = Int32.TryParse(input, out n);
            return check;
        }
        public static void Run_bai4()
        {
            int choice;
            do
            {
                //Tính toán hai phân số
                Console.WriteLine("=== Tinh toan hai phan so ===");
                PhanSo ps1 = NhapPhanSo("Phan so thu nhat");
                PhanSo ps2 = NhapPhanSo("Phan so thu hai");

                Console.WriteLine("\nKet qua:");
                Console.WriteLine($"Tong: {ps1 + ps2}");
                Console.WriteLine($"Hieu: {ps1 - ps2}");
                Console.WriteLine($"Tich: {ps1 * ps2}");
                Console.WriteLine($"Thuong: {ps1 / ps2}");

                //Quản lý danh sách phân số
                Console.WriteLine("\n=== Quan ly danh sach phan so ===");
                QuanLyPhanSo ql = new QuanLyPhanSo();
                ql.NhapDanhSach();

                Console.WriteLine("\nDanh sach phan so da nhap:");
                ql.XuatDanhSach();

                Console.WriteLine($"\nPhan so lon nhat: {ql.TimMax()}");

                ql.SapXepTangDan();
                Console.WriteLine("\nDanh sach sau khi sap xep tang dan:");
                ql.XuatDanhSach();
                Console.WriteLine();

                Console.WriteLine("Ban co muon thuc hien lai chuong trinh?");
                Console.WriteLine("1. Co");
                Console.WriteLine("0. Khong");
                Console.Write("Nhap lua chon: ");
                while (true)
                {
                    string input = Console.ReadLine();

                    bool isValid = int.TryParse(input, out choice);
                    if (!isValid)
                    {
                        Console.Write("Kieu du lieu khong dung, hay nhap lai: ");
                    }
                    else if (choice == 1 || choice == 0)
                        break;
                    else
                        Console.Write("Lua chon khong hop le, vui long nhap 0 hoac 1: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n=== Chuong trinh se duoc thuc hien lai ===\n");
                        break;
                    case 0:
                        Console.WriteLine("\n==== THOAT CHUONG TRINH 4 ====\n");
                        break;
                }
            } while (choice == 1);
        }
    }
}
