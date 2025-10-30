using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Bai01
    {
        struct Date
        {
            public int month;
            public int year;
        }

        static void NhapThangNam(ref Date date)
        {
            Console.WriteLine("Nhap thang nam");

            while (true)
            {
                Console.Write("Nhap thang: ");
                string input_month = Console.ReadLine();
                if (Int32.TryParse(input_month, out date.month))
                    break;
                else
                    Console.WriteLine("Nhap sai kieu du lieu, hay nhap lai thang");
            }

            while (true)
            {
                Console.Write("Nhap nam: ");
                string input_year = Console.ReadLine();
                if (Int32.TryParse(input_year, out date.year))
                    break;
                else
                    Console.WriteLine("Nhap sai kieu du lieu, hay nhap lai nam");
            }

            Console.WriteLine($"\nBan vua nhap: {date.month}/{date.year}");
        }

        static bool IsNamNhuan(int year)
        {
            return ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0));
        }

        static bool IsThangNamHopLe(Date date)
        {
            int month = date.month;
            int year = date.year;

            if (year < 1 || month < 1 || month > 12)
                return false;
            return true;
        }

        static int GetNgayTrongThang(Date date)
        {
            int[] ngayTrongThang = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (IsNamNhuan(date.year))
            {
                ngayTrongThang[1] = 29;
            }
            return ngayTrongThang[date.month - 1];
        }

        static int TinhThu(Date date)
        {
            int day = 1;
            int month = date.month;
            int year = date.year;

            if (month == 1)
            {
                month = 13;
                year--;
            }
            else if (month == 2)
            {
                month = 14;
                year--;
            }

            int q = day;
            int m = month;
            int K = year % 100;
            int J = year / 100;

            int h = (q + (13 * (m + 1)) / 5 + K + K / 4 + J / 4 + 5 * J) % 7;

            int thu = 0;
            switch (h)
            {
                case 0: thu = 6; break;
                case 1: thu = 0; break;
                case 2: thu = 1; break;
                case 3: thu = 2; break;
                case 4: thu = 3; break;
                case 5: thu = 4; break;
                case 6: thu = 5; break;
            }
            return thu;
        }

        static public void Run_Bai1()
        {
            int choice;
            do
            {
                Date date = new Date();

                while (true)
                {
                    NhapThangNam(ref date);
                    if (!IsThangNamHopLe(date))
                        Console.WriteLine("Thang nam khong hop le, vui long nhap lai.");
                    else
                        break;
                }

                int thu = TinhThu(date);
                int DayInMonth = GetNgayTrongThang(date);

                Console.WriteLine("\nSun Mon Tue Wed Thu Fri Sat");

                for (int i = 0; i < thu; i++)
                    Console.Write("    ");

                for (int i = 1; i <= DayInMonth; i++)
                {
                    Console.Write($"{i,3} ");
                    thu++;

                    if (thu == 7)
                    {
                        Console.WriteLine();
                        thu = 0;
                    }
                }
                Console.WriteLine("\n");

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
                        Console.WriteLine("\n==== THOAT CHUONG TRINH 1 ====\n");
                        break;
                }

            } while (choice == 1);
        }
    }
}
