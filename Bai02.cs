using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Bai02
    {
        static long GetFreeSpace(string path)
        {
            DriveInfo drive = new DriveInfo(Path.GetPathRoot(path));
            return drive.AvailableFreeSpace;
        }

        static string GetPath()
        {
            while (true)
            {
                Console.Write("Nhap duong dan thu muc: ");
                string path = Console.ReadLine();
                path = (path == null) ? "" : path.Trim();

                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("Duong dan khong duoc de trong, hay nhap lai.");
                    continue;
                }

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Thu muc khong ton tai, hay nhap lai.");
                    continue;
                }

                return path;
            }
        }

        static void PrintDirectoryContent(string path)
        {
            Console.WriteLine("\n Directory of " + path + "\n");

            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            long totalFileSize = 0;

            foreach (string dir in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                Console.WriteLine($"{di.LastWriteTime:MM/dd/yyyy  hh:mm tt}    <DIR>          {di.Name}");
            }

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                totalFileSize += fi.Length;
                Console.WriteLine($"{fi.LastWriteTime:MM/dd/yyyy  hh:mm tt}    {fi.Length,15:N0}  {fi.Name}");
            }

            Console.WriteLine();
            Console.WriteLine($"{files.Length,4} File(s) {totalFileSize,15:N0} bytes");
            Console.WriteLine($"{dirs.Length,4} Dir(s) {GetFreeSpace(path),15:N0} bytes free\n");
        }

        public static void Run_Bai2()
        {
            int choice;
            do
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("=== Liet ke thu muc (tuong tu lenh DIR) ===\n");

                string path = GetPath();
                PrintDirectoryContent(path);

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
                        Console.WriteLine("\n==== THOAT CHUONG TRINH 2 ====\n");
                        break;
                }

            } while (choice == 1);
        }
    }
}
