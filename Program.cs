using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("==== MENU CHUONG TRINH TONG ====\n");
                Console.WriteLine("0. Thoat chuong trinh.");
                Console.WriteLine("1. In lich cua thang da chon.");
                Console.WriteLine("2. Xuat ten tap tin va thu muc con.");
                Console.WriteLine("3. Ma tran.");
                Console.WriteLine("4. Quan ly phan so.");
                Console.WriteLine("5. Quan ly bat dong san.");
                Console.Write("Nhap lua chon: ");

                while (true)
                {
                    while (true)
                    {
                        string input_choice = Console.ReadLine();
                        if (Int32.TryParse(input_choice, out choice))
                        {
                            choice = int.Parse(input_choice);
                            break;
                        }
                        else
                            Console.WriteLine("Nhap sai kieu du lieu, hay nhap lai.");
                    }
                    if (choice < 0 || choice > 5)
                        Console.WriteLine("lua chon khong dung, hay nhap lai.");
                    else
                        break;
                }
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("\n==== KET THUC CHUONG TRINH ====\n");
                        break;
                    case 1:
                        Console.WriteLine("\n==== BAN DA CHON CHUONG TRINH 1 ====\n");
                        Bai01.Run_Bai1();
                        break;
                    case 2:
                        Console.WriteLine("\n==== BAN DA CHON CHUONG TRINH 2 ====\n");
                        Bai02.Run_Bai2();
                        break;
                    case 3:
                        Console.WriteLine("\n==== BAN DA CHON CHUONG TRINH 3 ====\n");
                        Bai03.Run_bai3();
                        break;
                    case 4:
                        Console.WriteLine("\n==== BAN DA CHON CHUONG TRINH 4 ====\n");
                        Bai04.Run_bai4();
                        break;
                    case 5:
                        Console.WriteLine("\n==== BAN DA CHON CHUONG TRINH 5 ====\n");
                        Bai05.Run_bai5();
                        break;
                }

            } while (choice != 0);
        }
    }
}
