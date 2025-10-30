using System;

namespace Bai1
{
    internal class Bai03
    {
        // Hàm nhập số nguyên (trả về true nếu nhập hợp lệ)
        static bool ReadInput(ref int n)
        {
            string input = Console.ReadLine();
            bool check = Int32.TryParse(input, out int value);
            if (check)
            {
                n = value;
                return true;
            }
            else
            {
                Console.Write("Nhap sai kieu du lieu, hay nhap lai: ");
                return false;
            }
        }

        // Hàm nhập ma trận
        static void TaoMaTran(ref int[,] a, ref int n, ref int m)
        {
            Console.Write("Nhap so dong (n>0): ");
            while (true)
            {
                bool check = ReadInput(ref n);
                if (check)
                {
                    if (n > 0)
                        break;
                    else
                        Console.Write("So dong phai lon hon 0, hay nhap lai: ");
                }
            }

            Console.Write("Nhap so cot (m>0): ");
            while (true)
            {
                bool check = ReadInput(ref m);
                if (check)
                {
                    if (m > 0)
                        break;
                    else
                        Console.Write("So cot phai lon hon 0, hay nhap lai: ");
                }
            }

            a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    while (true)
                    {
                        bool check = ReadInput(ref a[i, j]);
                        if (check)
                            break;
                    }
                }
            }
        }

        // Hàm xuất ma trận
        static void XuatMaTran(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j].ToString().PadLeft(5));
                Console.WriteLine();
            }
        }

        // Hàm tìm một số trong ma trận (in tất cả vị trí)
        static void TimPhanTu(int[,] a, int x)
        {
            bool found = false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] == x)
                    {
                        Console.WriteLine($"Phan tu {x} o vi tri [{i},{j}]");
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine($"Khong tim thay phan tu co gia tri {x}");
        }

        // Hàm kiểm tra số nguyên tố
        static bool IsPrime(int x)
        {
            if (x < 2) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;
            for (int i = 3; i * i <= x; i += 2)
                if (x % i == 0) return false;
            return true;
        }

        // Hàm xuất các phần tử là số nguyên tố
        static void XuatSNT(int[,] a)
        {
            Console.Write("\nCac phan tu la so nguyen to la: ");
            bool found = false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (IsPrime(a[i, j]))
                    {
                        Console.Write(a[i, j] + " ");
                        found = true;
                    }
                }
            }
            if (!found)
                Console.Write("Khong co phan tu nao la so nguyen to.");
            Console.WriteLine();
        }

        // Hàm xuất tất cả các dòng có nhiều số nguyên tố nhất
        static void XuatDongNhieuSNTNhat(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int[] primeCount = new int[n];
            int countmax = 0;

            // Đếm số SNT trên từng dòng
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                    if (IsPrime(a[i, j]))
                        count++;

                primeCount[i] = count;
                if (count > countmax)
                    countmax = count;
            }

            if (countmax == 0)
            {
                Console.WriteLine("\nKhong co dong nao co so nguyen to.");
                return;
            }

            Console.WriteLine($"\nCac dong co nhieu so nguyen to nhat (so luong {countmax} SNT):");
            for (int i = 0; i < n; i++)
            {
                if (primeCount[i] == countmax)
                {
                    Console.Write($"Dong {i+1}: ");
                    for (int j = 0; j < m; j++)
                        Console.Write(a[i, j] + " ");
                    Console.WriteLine();
                }
            }
        }

        public static void Run_bai3()
        {
            int dong = 0, cot = 0;
            int[,] a = null;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== TAO MA TRAN ===");
            TaoMaTran(ref a, ref dong, ref cot);

            Console.WriteLine("Ma tran vua tao:");
            XuatMaTran(a);

            int choice = -1;
            do
            {
                Console.WriteLine();
                Console.WriteLine(" ==== MENU CHUONG TRINH 3 ==== ");
                Console.WriteLine("0. Dung chuong trinh.");
                Console.WriteLine("1. Tao moi va xuat ma tran.");
                Console.WriteLine("2. Tim kiem mot phan tu trong ma tran.");
                Console.WriteLine("3. Xuat cac phan tu la so nguyen to.");
                Console.WriteLine("4. In ra cac dong co nhieu so nguyen to nhat.");
                Console.Write("Nhap lua chon: ");

                while (true)
                {
                    bool check = ReadInput(ref choice);
                    if (check)
                    {
                        if (choice >= 0 && choice <= 4)
                            break;
                        else
                            Console.Write("Lua chon khong hop le, hay chon lai (0-4): ");
                    }
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("\n==== THOAT CHUONG TRINH 3 ====\n");
                        break;

                    case 1:
                        Console.WriteLine("\n=== TAO MA TRAN MOI ===");
                        TaoMaTran(ref a, ref dong, ref cot);
                        Console.WriteLine("Ma tran vua tao:");
                        XuatMaTran(a);
                        break;

                    case 2:
                        int x = 0;
                        Console.Write("\nNhap so can tim: ");
                        while (true)
                        {
                            bool ok = ReadInput(ref x);
                            if (ok)
                                break;
                        }
                        TimPhanTu(a, x);
                        break;

                    case 3:
                        XuatSNT(a);
                        break;

                    case 4:
                        XuatDongNhieuSNTNhat(a);
                        break;
                }
            } while (choice != 0);
        }
    }
}